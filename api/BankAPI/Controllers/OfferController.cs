using BankAPI.BankAPI.Contracts.Offer;
using BankAPI.Data;
using BankAPI.FileManager;
using BankAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using System.Net.Mime;

namespace BankAPI.Controllers
{
    [ApiController]
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class OfferController : Controller
    {
        private readonly BankAPIDbContext dbContext;
        private readonly IFileManager fileManager;
        public OfferController(BankAPIDbContext _dbContext, IFileManager _fileManager)
        {
            dbContext = _dbContext;
            fileManager = _fileManager;
        }

        /// <summary>
        /// Get offer with id equal to offerId
        /// </summary>
        /// <param name="offerId"></param>
        /// /// <returns>Info about offer with offerId</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized (unauthenticated)</response>
        /// <response code="500">Internal Server Error</response>
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("/Offer/{offerId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetOffer(Guid offerId)
        {
            var offer = await dbContext.Offers.FindAsync(offerId);
            if (offer == null) return NotFound();
            return Ok(offer);
        }

        /// <summary>
        /// Get document of an offer with id equal to offerId by key
        /// </summary>
        /// <param name="offerId"></param>
        /// <param name="key"></param>
        /// /// <returns>Info about offer with offerId</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized (unauthenticated)</response>
        /// <response code="500">Internal Server Error</response>
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("/Offer/{offerId:guid}/document/{key}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Download(string key)
        {
            var imagBytes = await fileManager.Get(key);
            return new FileContentResult(imagBytes, "application/octet-stream")
            {
                FileDownloadName = Guid.NewGuid().ToString() + ".txt",
            };
        }


        /// <summary>
        /// Upload a document related to offer with id equal to offerId.
        /// </summary>
        /// <param name="offerId"></param>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized (unauthenticated)</response>
        /// <response code="500">Internal Server Error</response>
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("/Offer/{offerId:guid}/document/upload")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Upload([FromForm]FileModel model)
        {
            if (model.ImageFile != null)
            {
                await fileManager.Upload(model);
            }
            return Ok();
        }
        //sets statusDescription from Created (1) to Complete (6)
        /// <summary>
        /// Change offer's status to Complete.
        /// </summary>
        /// <param name="offerId"></param>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized (unauthenticated)</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("/Offer/{offerId:guid}/complete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Complete(Guid offerId)
        {
            var result = dbContext.Offers.SingleOrDefault(item => item.Id == offerId);
            if(result !=null)
            {
                result.StatusID = 6;
                result.StatusDescription = "Complete";
                await dbContext.SaveChangesAsync();
            }
            return Ok(result);
        }

        /// <summary>
        /// List all offers from the database.
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized (unauthenticated)</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet("/Offer/All")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ShowAll()
        {
            var offersFromDatabase = dbContext.Offers.ToList();

            return Ok(offersFromDatabase);
        }

        /// <summary>
        /// Change offer's status to Accepted.
        /// </summary>
        /// <param name="request"></param>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized (unauthenticated)</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost("/Offer/{offerId:guid}/Accept")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Accept(EmployeeChangeStatusRequest request)
        {
            var result = dbContext.Offers.SingleOrDefault(item => item.Id == request.offerId);
            // Trzeba dodac pole ApprovedBy i wpisac do niego request.Name
            if (result != null)
            {
                result.StatusID = 6;    // Accepted status
                result.StatusDescription = "Accepted";
                await dbContext.SaveChangesAsync();
            }
            return Ok();
        }

        /// <summary>
        /// Change offer's status to Rejected.
        /// </summary>
        /// <param name="request"></param>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized (unauthenticated)</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost("/Offer/{offerId:guid}/Reject")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Reject(EmployeeChangeStatusRequest request)
        {
            var result = dbContext.Offers.SingleOrDefault(item => item.Id == request.offerId);
            // Trzeba dodac pole ApprovedBy i wpisac do niego request.Name
            if (result != null)
            {
                result.StatusID = 8;    // Rejected status
                result.StatusDescription = "Rejected";
                await dbContext.SaveChangesAsync();
            }
            return Ok();
        }


    }
}
