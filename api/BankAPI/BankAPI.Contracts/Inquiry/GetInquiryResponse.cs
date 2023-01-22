namespace BankAPI.BankAPI.Contracts.Inquiry
{
    public class GetInquiryResponse
    {
        public Guid InquireId { get; }
        public DateTime CreationDate { get; }
        public Guid OfferId { get; }

        public GetInquiryResponse(Guid _inquireId, DateTime _creationDate, Guid _offerId)
        {
            InquireId = _inquireId;
            CreationDate = _creationDate;
            OfferId = _offerId;
        }
    }
}
