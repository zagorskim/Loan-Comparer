using Loans_Comparer.Entities.Enums;

namespace Loans_Comparer.Entities.Models
{
    public class JobDetails
    {
        public JobType typeId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime jobStartDate { get; set; }
        public DateTime jobEndDate { get; set; }
    }
}
