using Loans_Comparer.Entites;

namespace Loans_Comparer.Requests
{
    public class OfferResponseDto
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public double MoneyAmount { get; set; }
        public int InstallmentAmount { get; set; }
        public double Percentage { get; set; }
        public double MonthlyInstallment { get; set; }
        public string OfferStatus { get; set; }

        public static OfferResponseDto? CreateOfferResponse(Offer offer)
        {
            if (offer is null)
                return null;

            return new OfferResponseDto { Id = offer.Id,
                CreationDate = offer.CreationDate, 
                InstallmentAmount= offer.InstallmentAmount, 
                MoneyAmount= offer.MoneyAmount,
                MonthlyInstallment= offer.MonthlyInstallment,
                Percentage = offer.Percentage,
                OfferStatus = offer.Status};
        }
    }
}
