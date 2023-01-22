using Loans_Comparer.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Loans_Comparer.Models.DTOs
{
    public class ExternalRegisterDto
    {
        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Job type")]
        public JobType JobType { get; set; }
        [Required]
        [Display(Name = "Job start date")]
        public DateTime JobStartDate { get; set; }
        [Required]
        [Display(Name = "Job end date")]
        public DateTime JobEndDate { get; set; }
        [Required]
        [Display(Name = "Level icome")]
        public int LevelIncome { get; set; }
        [Required]
        [Display(Name = "Goverment id type")]
        public GovernmentDocumentTypes GovernmentIdType { get; set; }
        [Required]
        [Display(Name = "Goverment id")]
        public string GovernmentId { get; set; }
        [Required]
        [Display(Name = "Birth date")]
        public string BirthDate { get; set; }

    }
}
