using Loans_Comparer.Data;
using Loans_Comparer.Entites;
using Loans_Comparer.Entities.Enums;
using Loans_Comparer.Requests;
using Loans_Comparer.Requests.ExternalApi;
using Loans_Comparer.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Loans_Comparer.Services
{
    public interface IInquiryCreatingService
    {
        public Task CreateInquiry(InquiryExternalPostRequestDto request, List<Offer> offers, User user, Inquiry inquiry, string bankName);
        public Task CreateAnonymousInquiry(InquiryExternalPostRequestDto request, List<Offer> offers, Inquiry inquiry, string bankName);

    }
    public class InquiryCreatingService : IInquiryCreatingService
    {
        private readonly LoanComparerDbContext _dbContext;
        private readonly IBanksResolver _banksResolver;
        public InquiryCreatingService(LoanComparerDbContext dbContext, IBanksResolver banksResolver)
        {
            _banksResolver = banksResolver;
            _dbContext = dbContext;
        }
        public async Task CreateInquiry(InquiryExternalPostRequestDto request, List<Offer> offers, User user, Inquiry inquiry, string bankName)
        {
            var bankHandler = _banksResolver.Resolve(bankName);
            var createResp = bankHandler.CreateInquiry(request);
            var inquiryResp = bankHandler.GetExistingInquiry(createResp.inquireId);
            if (bankName == "TeachersBank")
            {
                while (inquiryResp.statusId != 3) // !"OfferPrepared"
                {
                    await Task.Delay(1000);
                    inquiryResp = bankHandler.GetExistingInquiry(createResp.inquireId);
                }
            }
            var offerResp = bankHandler.GetExistingOffer(inquiryResp.offerId);
            Offer bankOffer = new Entites.Offer()
            {
                Id = Guid.NewGuid(),
                CreationDate = offerResp.createDate,
                UserId = new Guid(user.Id),
                BankId = (BankNames)Enum.Parse(typeof(BankNames), bankName),
                InquiryId = inquiry.Id,
                ExternalOfferId = offerResp.id.ToString(),
                MoneyAmount = offerResp.requestedValue,
                InstallmentAmount = offerResp.requestedPeriodInMonth,
                Percentage = offerResp.percentage,
                MonthlyInstallment = offerResp.monthlyInstallment,
                Status = offerResp.statusDescription,
                DocumentLink = offerResp.documentLink,
                DocumentValidDate = offerResp.documentLinkValidDate
            };
            offers.Add(bankOffer);
            _dbContext.Offers.Add(bankOffer);
            _dbContext.SaveChanges();
            return;
        }

        public async Task CreateAnonymousInquiry(InquiryExternalPostRequestDto request, List<Offer> offers, Inquiry inquiry, string bankName)
        {
            var bankHandler = _banksResolver.Resolve(bankName);
            var createResp = bankHandler.CreateInquiry(request);
            var inquiryResp = bankHandler.GetExistingInquiry(createResp.inquireId);
            if (bankName == "TeachersBank")
            {
                while (inquiryResp.statusId != 3) // !"OfferPrepared"
                {
                    await Task.Delay(1000);
                    inquiryResp = bankHandler.GetExistingInquiry(createResp.inquireId);
                }
            }
            var offerResp = bankHandler.GetExistingOffer(inquiryResp.offerId);
            Offer bankOffer = new Entites.Offer()
            {
                Id = Guid.NewGuid(),
                CreationDate = offerResp.createDate,
                UserId = null,
                BankId = (BankNames)Enum.Parse(typeof(BankNames), bankName),
                InquiryId = inquiry.Id,
                ExternalOfferId = offerResp.id.ToString(),
                MoneyAmount = offerResp.requestedValue,
                InstallmentAmount = offerResp.requestedPeriodInMonth,
                Percentage = offerResp.percentage,
                MonthlyInstallment = offerResp.monthlyInstallment,
                Status = offerResp.statusDescription,
                DocumentLink = offerResp.documentLink,
                DocumentValidDate = offerResp.documentLinkValidDate
            };
            offers.Add(bankOffer);
            _dbContext.Offers.Add(bankOffer);
            _dbContext.SaveChanges();
            return;
        }

    }
}
