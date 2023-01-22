using Azure.Core;
using Loans_Comparer.Data;
using Loans_Comparer.Entities.Enums;
using Loans_Comparer.Requests;
using Loans_Comparer.Requests.ExternalApi;
using Loans_Comparer.Services;
using Loans_Comparer.Services.EmailService;
using Loans_Comparer.Utilities;
using Loans_Comparer.Utilities.BankHandlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Loans_Comparer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly LoanComparerDbContext _dbContext;
        private readonly IBanksResolver _banksResolver;
        private readonly IOfferRequestingService _offerRequestingService;

        public OfferController(LoanComparerDbContext dbContext, IBanksResolver banksResolver, IOfferRequestingService offerRequestingService)
        {
            _dbContext = dbContext;
            _banksResolver = banksResolver;
            _offerRequestingService = offerRequestingService;
        }

        [HttpPost("Request")]
        [Authorize(Roles = "Simple")]
        public async Task<ActionResult> SendOfferRequest([FromForm] OfferRequestDto request)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string Email;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                Email = userClaims.FirstOrDefault(u => u.Type == ClaimTypes.Email)?.Value;
                var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == Email);
                if (user == null)
                {
                    return NotFound();
                }

                var offer = await _dbContext.Offers.FirstOrDefaultAsync(o => o.Id == request.Id);
                if (offer == null)
                {
                    return NotFound();
                }
                if (offer.UserId.ToString() != user.Id)
                {
                    return Unauthorized();
                }

                var inquiry = _dbContext.Inquiries.FirstOrDefault(i => i.Id == request.inquiryId);
                if (inquiry == null)
                {
                    _dbContext.Offers.RemoveRange(_dbContext.Offers.Where(o => o.InquiryId == request.inquiryId)); //&& o.Id != offer.Id
                    _dbContext.SaveChanges();
                    return StatusCode(StatusCodes.Status500InternalServerError, null);
                }
                _dbContext.Offers.RemoveRange(_dbContext.Offers.Where(o => o.InquiryId == request.inquiryId && o.Id != offer.Id));
                inquiry.BankId = request.BankId;

                _offerRequestingService.RequestOffer(request, user.Email);
                _dbContext.SaveChanges();
                return Ok();

            }
            return StatusCode(StatusCodes.Status500InternalServerError, null);
        }

        [HttpPost("Anonymous-Request")]
        [AllowAnonymous]
        public async Task<ActionResult> SendAnonymousOfferRequest([FromForm] AnonymousOfferRequestDto request)
        {

            var offer = await _dbContext.Offers.FirstOrDefaultAsync(o => o.Id == request.Id);
            if (offer == null)
            {
                return NotFound();
            }
            if (offer.UserId != null)
            {
                return Unauthorized();
            }

            var inquiry = _dbContext.Inquiries.FirstOrDefault(i => i.Id == request.inquiryId);
            if (inquiry == null)
            {
                _dbContext.Offers.RemoveRange(_dbContext.Offers.Where(o => o.InquiryId == request.inquiryId)); //&& o.Id != offer.Id
                _dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status500InternalServerError, null);
            }
            _dbContext.Offers.RemoveRange(_dbContext.Offers.Where(o => o.InquiryId == request.inquiryId && o.Id != offer.Id));
            inquiry.BankId = request.BankId;

            var offerReq = new OfferRequestDto()
            {
                Id = request.Id,
                BankId = request.BankId,
                inquiryId = request.Id,
                ExternalOfferId = request.ExternalOfferId,
                formFile = request.formFile
            };
            _offerRequestingService.RequestOffer(offerReq, request.email);
            _dbContext.SaveChanges();
            return Ok();

        }

        [HttpPost("Complete")]
        [Authorize(Roles = "Employee")]
        public async Task<ActionResult> CompleteOffer(OfferCompleteDto request)
        {
            var bankHandler = _banksResolver.Resolve(Enum.GetName(typeof(BankNames), request.BankId));
            bankHandler.CompleteOffer(request.ExternalOfferId);
            return Ok();
        }

        [HttpPost("Accept")]
        [Authorize(Roles = "Employee")]
        public async Task<ActionResult> AcceptOffer(string offerId)
        {
            var bankHandler = _banksResolver.Resolve("LocalBank");
            bankHandler.AcceptOffer(offerId);
            return Ok();
        }

        [HttpPost("Reject")]
        [Authorize(Roles = "Employee")]
        public async Task<ActionResult> RejectOffer(string offerId)
        {
            var bankHandler = _banksResolver.Resolve("LocalBank");
            bankHandler.RejectOffer(offerId);
            return Ok();
        }

        [HttpGet("Details")]
        [AllowAnonymous]
        public async Task<ActionResult> ShowDetails(string offerId)
        {
            var offer = _dbContext.Offers.FirstOrDefault(o => o.Id.ToString() == offerId);
            return Ok(offer);
        }

        [HttpGet("All")]
        [Authorize(Roles = "Employee")]
        public async Task<ActionResult> ShowAllOffers()
        {
            var bankHandler = _banksResolver.Resolve("LocalBank");
            var offers = bankHandler.OffersShowAll();
            return Ok(offers);
        }
    }
}
