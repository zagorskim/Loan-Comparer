using Loans_Comparer.Entities.Enums;

namespace Loans_Comparer.Requests
{
    public class OfferCompleteDto
    {
        public BankNames BankId { get; set; }
        public string ExternalOfferId { get; set; }
    }
}
