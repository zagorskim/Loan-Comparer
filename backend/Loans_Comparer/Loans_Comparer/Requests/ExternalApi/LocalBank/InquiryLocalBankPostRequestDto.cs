using Loans_Comparer.Entities.Enums;
using Microsoft.Identity.Client;
using System.Transactions;

namespace Loans_Comparer.Requests.ExternalApi.LocalBank
{
    public class InquiryLocalBankPostRequestDto
    {
        public double moneyAmount { get; set; }
        public int installmentsNumber { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public GovernmentDocumentTypes documentType { get; set; }
        public string documentId { get; set; }
        public JobType jobType { get; set; }
        public double incomeLevel { get; set; }
    }
}
