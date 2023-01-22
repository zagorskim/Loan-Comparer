namespace BankAPI.Contracts.Inquiry
{
    public class CreateInquiryRequest
    {
        public decimal MoneyAmount { get; }
        public int InstallmentsNumber { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public int DocumentType { get; }
        public string DocumentId { get; }
        public int JobType { get; }
        public decimal IncomeLevel { get; }

        public CreateInquiryRequest(decimal moneyAmount, int installmentsNumber, string firstName, string lastName, int documentType, string documentId, int jobType, decimal incomeLevel)
        {
            MoneyAmount = moneyAmount;
            InstallmentsNumber = installmentsNumber;
            FirstName = firstName;
            LastName = lastName;
            DocumentType = documentType;
            DocumentId = documentId;
            JobType = jobType;
            IncomeLevel = incomeLevel;
        }
    }
}