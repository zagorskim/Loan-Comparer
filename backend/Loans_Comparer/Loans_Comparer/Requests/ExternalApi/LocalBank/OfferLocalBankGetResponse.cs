namespace Loans_Comparer.Requests.ExternalApi.LocalBank
{
    public class OfferLocalBankGetResponse
    {
        public string id { get; set; }
        public double percentage { get; set; }
        public double monthlyInstallment { get; set; }
        public double requesedValue { get; set; }
        public int requestedPeriodInMonth { get; set; }
        public int statusID { get; set; }
        public string statusDescription { get; set; }
        public string inquireId { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }
        public string? documentLink { get; set; }
        public DateTime? documentLinkValidDate { get; set; }
    }
}
