namespace Loans_Comparer.Requests.ExternalApi.OtherBank
{
    public class OfferOtherBankGetResponseDto
    {
        public string id { get; set; }
        public double percentage { get; set; }
        public double monthlyInstallment { get; set; }
        public double requesedValue { get; set; }
        public int requestedPeriodInMonth { get; set; }
        public int statusId { get; set; }
        public string statusDescription { get; set; }
        public string inquireId { get; set; }
        public DateTime createDate { get; set; }
        public DateTime updateDate { get; set; }
        public string documentLink { get; set; }
        public DateTime documentLinkValidDate { get; set; }
    }
}
