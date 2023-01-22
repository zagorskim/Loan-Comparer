using Microsoft.AspNetCore.Identity;
using Loans_Comparer.Entities.Enums;

namespace Loans_Comparer.Entites
{   
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty; 
        public DateTime CreationDate { get; set; }
        public JobType JobType { get; set; }
        public DateTime JobStartDate { get; set; }
        public DateTime JobEndDate { get; set; }
        public int LevelIncome { get; set; }
        public string GovernmentId { get; set; } = string.Empty;
        public GovernmentDocumentTypes GovernmentIdType { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }
        public string BirthDate { get; set; }
    }

    
}
