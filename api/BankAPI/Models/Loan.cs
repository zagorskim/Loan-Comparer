using System.ComponentModel.DataAnnotations.Schema;

namespace BankAPI.Models
{
    public class Inquiry
    {
        public Guid Id { get; set; }

        public DateTime CreationDate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal MoneyAmount { get; set; }
        public int InstallmentsCount { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DocumentType { get; set; }
        public string DocumentId { get; set; }
        public int JobType { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal IncomeLevel { get; set; }

        public Inquiry()
        {

        }
        public Inquiry(Guid _id, DateTime _creationDate, decimal _moneyAmount, int _installmentsCount, string _firstName, string _lastName,
            int _documentType, string _documentId, int _jobType, decimal _incomeLevel)
        {
            //enforce invariants
            Id = _id;
            CreationDate = _creationDate;
            MoneyAmount = _moneyAmount;
            InstallmentsCount = _installmentsCount;
            FirstName = _firstName;
            LastName = _lastName;
            DocumentType = _documentType;
            DocumentId = _documentId;
            JobType = _jobType;
            IncomeLevel = _incomeLevel;
        }
    }
}
