using Microsoft.Identity.Client;

namespace Loans_Comparer.Requests.ExternalApi.LocalBank
{
    public class InquiryLocalBankDto
    {
        public string id { get; set; }
        public DateTime creationDate { get; set; }
        public double moneyAmount { get; set; }
        public int installmentsCount { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int documentType { get; set; }
        public string documentId { get; set; }
        public int jobType { get; set; }
        public double incomeLevel { get; set; }
    }
}
