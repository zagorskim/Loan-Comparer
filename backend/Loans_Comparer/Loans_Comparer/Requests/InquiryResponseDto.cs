using Loans_Comparer.Entites;
using Loans_Comparer.Entities.Enums;

namespace Loans_Comparer.Requests
{
    public class InquiryResponseDto
    {
        public Guid InquiryId {get; set;}
        public BankNames BankId { get; set; }
        public DateTime CreationDate { get; set; }
        public double MoneyAmount { get; set; }
        public int InstallmentsAmount { get; set; }
        public OfferResponseDto? OfferFromBank { get; set; }
    }

    
}
