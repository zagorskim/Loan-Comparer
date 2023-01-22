using Loans_Comparer.Entities.Enums;
using Microsoft.Identity.Client;

namespace Loans_Comparer.Requests.ExternalApi.OtherBank
{
    public class InquiryOtherBankPostRequestDto
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
