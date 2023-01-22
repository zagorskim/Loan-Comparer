using Loans_Comparer.Entities.Models;
using System.ComponentModel.DataAnnotations;

namespace Loans_Comparer.Requests.ExternalApi
{
    public class InquiryExternalPostRequestDto
    {
        [Range(0.0, Double.MaxValue,
            ErrorMessage = "The field {0} must be greater than {1}.")]
        public double value { get; set; }
        public int installmentsNumber { get; set; }
        public PersonalData personalData { get; set; }
        public GovernmentDocument governmentDocument { get; set; }
        public JobDetails jobDetails { get; set; }
    }
}
