namespace Loans_Comparer.Requests.ExternalApi
{
    public class InquiryExternalGetResponseDto
    {
        public string inquireId { get; set; }
        public DateTime createDate { get; set; }
        public int statusId { get; set; }
        public string statusDescription { get; set; }
        public string offerId { get; set; }

    }
}
