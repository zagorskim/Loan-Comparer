using Loans_Comparer.Entities.Enums;

namespace Loans_Comparer.Entites
{
    public class Inquiry
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid? UserId { get; set; }
        public BankNames BankId { get; set; }
        public double MoneyAmount { get; set; }
        public int InstallmentsAmount { get; set; }
    }
}
