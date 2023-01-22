using System.ComponentModel.DataAnnotations.Schema;

namespace BankAPI.Models
{
    public class Offer
    {
        public Guid Id { get; set; }
        public int Percentage { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal MonthlyInstallment { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal RequesedValue { get; set; }
        public int RequestedPeriodInMonth { get; set; }
        public int StatusID { get; set; }
        public string StatusDescription { get; set; }
        public Guid InquireId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string DocumentLink { get; set; }
        public DateTime DocumentLinkValidDate { get; set; }

        public Offer()
        {
        }

        public Offer(Guid id, int percentage, decimal monthlyInstallment, decimal requesedValue, int requestedPeriodInMonth, int statusID,
            string statusDescription, Guid inquireId, DateTime createdDate, DateTime updatedDate, string documentLink, DateTime documentLinkValidDate)
        {
            Id = id;
            Percentage = percentage;
            MonthlyInstallment = monthlyInstallment;
            RequesedValue = requesedValue;
            RequestedPeriodInMonth = requestedPeriodInMonth;
            StatusID = statusID;
            StatusDescription = statusDescription;
            InquireId = inquireId;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
            DocumentLink = documentLink; //edit
            DocumentLinkValidDate = documentLinkValidDate; //edit
        }
    }
}
