using Loans_Comparer.Data;
using Loans_Comparer.Entites;
using Loans_Comparer.Entities.Enums;
using Loans_Comparer.Requests;
using Loans_Comparer.Requests.ExternalApi;
using Loans_Comparer.Services.EmailHostedService;
using Loans_Comparer.Services.EmailService;
using Loans_Comparer.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Loans_Comparer.Services
{
    public interface IOfferRequestingService
    {
        public Task RequestOffer(OfferRequestDto request, string email);
    }
    public class OfferRequestingService : IOfferRequestingService
    {
        private readonly LoanComparerDbContext _dbContext;
        private readonly IBanksResolver _banksResolver;
        private readonly ISendGridEmail _emailService;
        //private readonly IBackgroundTaskQueue _backgroundTaskQueue;
        private readonly ILogger<OfferRequestingService> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly IBackgroundOfferTasks _offers;

        public OfferRequestingService(LoanComparerDbContext dbContext,
            IBackgroundOfferTasks offers, IBanksResolver banksResolver, ISendGridEmail emailService, ILogger<OfferRequestingService> logger, IServiceProvider serviceProvider)
        {
            _offers = offers;
            _banksResolver = banksResolver;
            _dbContext = dbContext;
            _emailService = emailService;
            //_backgroundTaskQueue = backgroundTaskQueue;
            _logger = logger;
            _serviceProvider = serviceProvider;
        }
        public async Task RequestOffer(OfferRequestDto request, string email)
        {
            var bankHandler = _banksResolver.Resolve(Enum.GetName(typeof(BankNames), request.BankId));
            var offerResp = bankHandler.UploadDocument(request.ExternalOfferId, request.formFile);
            var emailDto = new SendGridDto()
            {
                Subject = "Submitted inquiry",
                To = email,
                TextContent = $"Inquiry {request.inquiryId} to bank {Enum.GetName(typeof(BankNames), request.BankId)} was submitted."
            };
            var context = _dbContext;
            await _emailService.SendEmailAsync(emailDto);

            _offers.Enqueue(new EmailTask()
            {
                Id = request.Id,
                inquiryId = request.inquiryId,
                BankId = request.BankId,
                ExternalOfferId = request.ExternalOfferId,
                email = email
            });
            return;
        }
    }
}
