using Microsoft.AspNetCore.Mvc;
using BankAPI.Contracts.Inquiry;
using BankAPI.Models;
using BankAPI.Data;
using BankAPI.OfferCreator;
using BankAPI.FileManager;
using System.Net;
using BankAPI.BankAPI.Contracts.Inquiry;
using Microsoft.Identity.Web.Resource;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Net.Mime;

//[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
//[Authorize]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
[ApiController]
public class InquiryController : ControllerBase
{
    private readonly BankAPIDbContext dbContext;
    private readonly IFileManager fileManager;
    public InquiryController(BankAPIDbContext _dbContext, IFileManager _fileManager)
    {
        dbContext = _dbContext;
        fileManager = _fileManager;

    }
    /// <summary>
    /// Create an inquiry based on given request
    /// </summary>
    /// <param name="request"></param>
    /// <returns>A newly created Inquiry</returns>
    /// <remarks>
    /// The moneyAmount, installmentsNumber and incomeLevel values have to be bigger than 0.
    /// </remarks>
    /// <response code="201">Returns the newly created Inquiry</response>
    /// <response code="400">Bad Request</response>
    /// <response code="401">Unauthorized (unauthenticated)</response>
    /// <response code="500">Internal Server Error</response>

    [HttpPost("/api/Inquire")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateInquiryAsync(CreateInquiryRequest request)
    {
        //check for valid parameters
        if (request.MoneyAmount <= 0 || request.InstallmentsNumber<1 || request.IncomeLevel<=0)
        {
            throw new BadHttpRequestException(HttpStatusCode.BadRequest.ToString());
        }

        Guid guid = Guid.NewGuid();
        DateTime now = DateTime.Now;
        var inquiry = new Inquiry(guid, now, request.MoneyAmount, request.InstallmentsNumber, request.FirstName, request.LastName,
            request.DocumentType, request.DocumentId, request.JobType, request.IncomeLevel);

        //save to database
        await dbContext.Inquiries.AddAsync(inquiry);
        await dbContext.SaveChangesAsync();

        var response = new CreateInquiryResponse(guid,now);
        return CreatedAtAction(nameof(CreateInquiryAsync), new {id=guid}, response);
    }

    /// <summary>
    /// Get inquiry with id equal to inquireId
    /// </summary>
    /// <param name="inquireId"></param>
    /// /// <returns>inquireId, offerId (id of an offer created for given inquiry) and creation date.</returns>
    /// <response code="200">Success</response>
    /// <response code="400">Bad Request</response>
    /// <response code="401">Unauthorized (unauthenticated)</response>
    /// <response code="500">Internal Server Error</response>
    [HttpGet("/api/Inquire/{inquireId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetInquiry([FromRoute] Guid inquireId)
    {
        var inquiry = await dbContext.Inquiries.FindAsync(inquireId);
        if (inquiry == null) return NotFound();

        //create offer
        Offer offer = OfferCreator.GetOffer(inquiry, fileManager);
        await dbContext.Offers.AddAsync(offer);
        await dbContext.SaveChangesAsync();

        return Ok(new GetInquiryResponse(inquireId, inquiry.CreationDate,offer.Id));
    }

    /// <summary>
    /// List all inquiries from the database.
    /// </summary>
    /// <response code="200">Success</response>
    /// <response code="400">Bad Request</response>
    /// <response code="401">Unauthorized (unauthenticated)</response>
    /// <response code="500">Internal Server Error</response>
    [HttpGet("/api/Inquire/All")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ShowAll()
    {
        var inquiresFromDatabase = dbContext.Inquiries.ToList();

        return Ok(inquiresFromDatabase);
    }
}
