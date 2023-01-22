using Loans_Comparer.Entities.Enums;

namespace Loans_Comparer.Requests
{
    public class UserInfoDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public string JobType { get; set; }
        public DateTime JobStartDate { get; set; }
        public DateTime JobEndDate { get; set; }
        public int LevelIncome { get; set; }
        public string GovernmentId { get; set; } = string.Empty;
        public string GovernmentIdType { get; set; }
        public string BankName { get; set; }
        public string Role { get; set; }
        public string BirthDate { get; set; }
    }
}
