using Loans_Comparer.Data;
using Loans_Comparer.Entites;
using Loans_Comparer.Requests;
using Loans_Comparer.Requests.ExternalApi;
using Loans_Comparer.Services;
using Loans_Comparer.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Odbc;
using System.Dynamic;
using System.Security.Claims;

namespace Loans_Comparer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InquiryController : ControllerBase
    {
        private readonly LoanComparerDbContext _dbContext;
        private readonly IBanksResolver _banksResolver;
        private readonly IInquiryCreatingService _inquiryCreatingService;

        public InquiryController(LoanComparerDbContext dbContext, IBanksResolver banksResolver, IInquiryCreatingService inquiryCreatingService)
        {
            _dbContext = dbContext;
            _banksResolver = banksResolver;
            _inquiryCreatingService = inquiryCreatingService;
        }

        [HttpGet("GetInquiries")]
        //ToDo add roles and filtering by role
        [Authorize]
        public async Task<IActionResult> GetInquires()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;
                var email = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
                var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
                var claimType = userClaims.ElementAt(1).Value;

                var inquires = new List<InquiryResponseDto>();
                var inquiresFromDatabase = _dbContext.Inquiries.ToList();
                IEnumerable<Inquiry> userInquires;

                if (claimType == "Simple")
                {
                    userInquires = inquiresFromDatabase.Where(x => x.UserId == new Guid(user.Id)).ToList();                 
                }
                else if(claimType == "Admin" || claimType == "Employee")
                {
                    userInquires = inquiresFromDatabase;
                }
                else
                {
                    return StatusCode(StatusCodes.Status403Forbidden, "Identity");
                }

                foreach (var inq in userInquires)
                {
                    var offerFromInquiry = _dbContext.Offers.FirstOrDefault(x => x.InquiryId == inq.Id);
                    var inquiry = new InquiryResponseDto()
                    {
                        InquiryId = inq.Id,
                        BankId = inq.BankId,
                        CreationDate = inq.CreationDate,
                        InstallmentsAmount = inq.InstallmentsAmount,
                        MoneyAmount = inq.MoneyAmount,
                        OfferFromBank = OfferResponseDto.CreateOfferResponse(offerFromInquiry)
                    };
                    inquires.Add(inquiry);
                }

                return Ok(inquires);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, "Identity");
        }

        [HttpPost("CreateInquiry")]
        [Authorize(Roles = "Simple")]
        public async Task<ActionResult> CreateInquiry([FromBody] InquiryExternalPostRequestDto request)
        {
            if(request.installmentsNumber <= 0 || request.value <= 0)
            {
                return BadRequest();
            }
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string Email;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                Email = userClaims.FirstOrDefault(u => u.Type == ClaimTypes.Email)?.Value;
                var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == Email);

                Inquiry inquiry = new Inquiry()
                {
                    Id = Guid.NewGuid(),
                    CreationDate = DateTime.Now,
                    UserId = new Guid(user.Id),
                    BankId = 0,
                    MoneyAmount = request.value,
                    InstallmentsAmount = request.installmentsNumber
                };
                await _dbContext.Inquiries.AddAsync(inquiry);
                List<Offer> offers = new List<Offer>();

                // For teachers bank
                await _inquiryCreatingService.CreateInquiry(request, offers, user, inquiry, "TeachersBank");
                //////////////////////

                // For local bank
                await _inquiryCreatingService.CreateInquiry(request, offers, user, inquiry, "LocalBank");
                //////////////////////

                // For other bank
                await _inquiryCreatingService.CreateInquiry(request, offers, user, inquiry, "OtherBank");
                //////////////////////

                _dbContext.SaveChanges();
                return Ok(new OffersFromBanksDto()
                {
                    offers = offers
                });
            }

            return StatusCode(StatusCodes.Status500InternalServerError, null);
        }

        [HttpPost("Anonymous-CreateInquiry")]
        [AllowAnonymous]
        public async Task<ActionResult> CreateAnonymousInquiry([FromBody] InquiryExternalPostRequestDto request)
        {
            Inquiry inquiry = new Inquiry()
            {
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                UserId = null,
                BankId = 0,
                MoneyAmount = request.value,
                InstallmentsAmount = request.installmentsNumber
            };
            await _dbContext.Inquiries.AddAsync(inquiry);
            List<Offer> offers = new List<Offer>();

            // For teachers bank
            await _inquiryCreatingService.CreateAnonymousInquiry(request, offers, inquiry, "TeachersBank");
            //////////////////////

            // For local bank
            await _inquiryCreatingService.CreateAnonymousInquiry(request, offers, inquiry, "LocalBank");
            //////////////////////

            // For other bank
            await _inquiryCreatingService.CreateAnonymousInquiry(request, offers, inquiry, "OtherBank");
            //////////////////////

            _dbContext.SaveChanges();
            return Ok(new OffersFromBanksDto()
            {
                offers = offers
            });
        }

        [HttpGet("All")]
        [Authorize(Roles = "Employee")]
        public async Task<ActionResult> ShowAllInquires()
        {
            var bankHandler = _banksResolver.Resolve("LocalBank");
            var inquires = bankHandler.InquiresShowAll();
            return Ok(inquires);
        }
    }
}
