namespace BankAPI.Contracts.Inquiry
{
    public class CreateInquiryResponse
    {
        public Guid InquireId { get; }
        public DateTime CreationDate{ get; }

        public CreateInquiryResponse(Guid _inquireId, DateTime _creationDate)
        {
            InquireId = _inquireId;
            CreationDate = _creationDate;
        }
    }
}