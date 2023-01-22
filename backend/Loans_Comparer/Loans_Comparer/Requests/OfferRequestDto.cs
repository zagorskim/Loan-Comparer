using Loans_Comparer.Entities.Enums;

namespace Loans_Comparer.Requests
{
    public class OfferRequestDto
    {
        public Guid Id { get; set; }
        public Guid inquiryId { get; set; }
        public BankNames BankId { get; set; }
        public string ExternalOfferId { get; set; }
        public IFormFile formFile { get; set; }
    }
}
