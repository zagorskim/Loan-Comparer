using Loans_Comparer.Data;
using Loans_Comparer.Entites;
using Loans_Comparer.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.Google;
using Google.Apis.Auth;
using Microsoft.Net.Http.Headers;
using Google.Apis.Auth.OAuth2;
using Loans_Comparer.Utilities.BankHandlers;
using System.Security.Cryptography;
using System;
using Loans_Comparer.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Loans_Comparer.Requests;
using Loans_Comparer.Entities.Enums;

namespace Loans_Comparer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly LoanComparerDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountController(LoanComparerDbContext dbContext, UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterDto request)
        {
            var userExists = await _userManager.FindByNameAsync(request.Email);
            if (userExists != null)
                return StatusCode(409);

            User user = new User
            {
                Email = request.Email,
                UserName = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                JobType = request.JobType,
                JobStartDate = request.JobStartDate,
                JobEndDate = request.JobEndDate,
                LevelIncome = request.LevelIncome,
                GovernmentIdType = request.GovernmentIdType,
                GovernmentId = request.GovernmentId,
                CreationDate = DateTime.Now,
                BirthDate = request.BirthDate
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, null);
            await _userManager.AddToRoleAsync(user, "Simple");
            return Ok("Registered.");
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDto request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email)
                };
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:Issuer"],
                    audience: _configuration["JWT:Audience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                var refreshToken = GenerateRefreshToken();
                SetRefreshToken(refreshToken, user.Id);

                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }
            return Unauthorized("Wrong email or password");
        }

        private RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7),
            };
            return refreshToken;
        }

        private void SetRefreshToken(RefreshToken newRefreshToken, string guid)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefreshToken.Expires
            };
            Response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOptions);

            var user = _dbContext.Users.FirstOrDefault(x => x.Id == guid);
            if (user != null)
            {
                user.RefreshToken = newRefreshToken.Token;
                user.TokenCreated = newRefreshToken.Created;
                user.TokenExpires = newRefreshToken.Expires;
            }
            _dbContext.SaveChanges();
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<string>> RefreshToken([FromBody] string email)
        {
            var refreshToken = Request.Cookies["refreshToken"];

            var user = _dbContext.Users.FirstOrDefault(x => x.Email == email);
            if (user != null)
            {
                if (!user.RefreshToken.Equals(refreshToken))
                {
                    return Unauthorized("Invalid refresh token.");
                }
                else if (user.TokenExpires < DateTime.Now)
                {
                    return Unauthorized("Token expired.");
                }
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, user.Email)
                    };
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:Issuer"],
                    audience: _configuration["JWT:Audience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                var newRefreshToken = GenerateRefreshToken();
                SetRefreshToken(newRefreshToken, user.Id);
                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }
            return Unauthorized();
        }

        [HttpPost("external-login")]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLogin()
        {
            var accessToken = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            GoogleJsonWebSignature.Payload payload = await GoogleJsonWebSignature.ValidateAsync(accessToken);
            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(accessToken);
            if (payload != null)
            {

                if (jwt != null)
                {
                    var userClaims = jwt.Claims;

                    string? Email = null;
                    if (userClaims != null)
                    {
                        Email = userClaims.FirstOrDefault(o => o.Type == "email")?.Value;
                    }
                    var user = await _userManager.FindByEmailAsync(Email);

                    if (user == null)
                    {
                        return Ok("Need to register.");
                    }

                    var userRoles = await _userManager.GetRolesAsync(user);
                    var authClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, user.Email)
                    };
                    foreach (var userRole in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                    }
                    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
                    var token = new JwtSecurityToken(
                        issuer: _configuration["JWT:Issuer"],
                        audience: _configuration["JWT:Audience"],
                        expires: DateTime.Now.AddHours(3),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                        );

                    var refreshToken = GenerateRefreshToken();
                    SetRefreshToken(refreshToken, user.Id);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
            }
            return BadRequest("Invalid token");
        }

        [HttpPost("external-register")]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalRegister([FromBody] ExternalRegisterDto request)
        {
            var accessToken = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            GoogleJsonWebSignature.Payload payload = await GoogleJsonWebSignature.ValidateAsync(accessToken);
            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(accessToken);
            if (payload != null)
            {
                if (jwt != null)
                {
                    var userClaims = jwt.Claims;

                    string? Email = null;
                    if (userClaims != null)
                    {
                        Email = userClaims.FirstOrDefault(o => o.Type == "email")?.Value;
                    }
                    var userExists = await _userManager.FindByNameAsync(Email);
                    if (userExists != null)
                        return StatusCode(409);

                    User userReg = new User
                    {
                        Email = Email,
                        UserName = Email,
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        JobType = request.JobType,
                        JobStartDate = request.JobStartDate,
                        JobEndDate = request.JobEndDate,
                        LevelIncome = request.LevelIncome,
                        GovernmentIdType = request.GovernmentIdType,
                        GovernmentId = request.GovernmentId,
                        CreationDate = DateTime.Now,
                        BirthDate = request.BirthDate
                    };
                    var result = await _userManager.CreateAsync(userReg);
                    if (!result.Succeeded)
                        return StatusCode(StatusCodes.Status500InternalServerError, null);
                    await _userManager.AddToRoleAsync(userReg, "Simple");
                    return Ok("Registered.");
                }
            }
            return BadRequest("Invalid token");
        }



        [HttpGet("count")]
        [AllowAnonymous]
        public ActionResult<int> GetUsersCount()
        {
            int usersCount = _dbContext.Users.Count();

            return usersCount;
        }

        [HttpGet("info")]
        [Authorize]
        public async Task<IActionResult> GetUserInfo()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string Email;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                Email = userClaims.FirstOrDefault(u => u.Type == ClaimTypes.Email)?.Value;
                var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == Email);

                return Ok(new UserInfoDto()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    CreationDate = user.CreationDate,
                    JobType = user.JobType == null ? null : Enum.GetName(typeof(JobType), user.JobType),
                    JobStartDate = user.JobStartDate,
                    JobEndDate = user.JobEndDate,
                    LevelIncome = user.LevelIncome,
                    GovernmentId = user.GovernmentId,
                    GovernmentIdType = user.GovernmentIdType == null ? null : Enum.GetName(typeof(GovernmentDocumentTypes), user.GovernmentIdType),
                    Role = userClaims.FirstOrDefault(u => u.Type == ClaimTypes.Role)?.Value,
                    BirthDate = user.BirthDate
                });
            }
            return StatusCode(StatusCodes.Status500InternalServerError, null);
        }
    }
}
