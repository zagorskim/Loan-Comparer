using Loans_Comparer.Entities.Enums;

namespace Loans_Comparer.Entites
{
    public class Offer
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid? UserId { get; set; }
        public BankNames BankId { get; set; }
        public Guid InquiryId { get; set; }
        public string ExternalOfferId { get; set; }
        public double MoneyAmount { get; set; }
        public int InstallmentAmount { get; set; }
        public double Percentage { get; set; }
        public double MonthlyInstallment { get; set; }
        public string Status { get; set; }
        public string? DocumentLink { get; set; }
        public DateTime? DocumentValidDate { get; set; }
    }
}
