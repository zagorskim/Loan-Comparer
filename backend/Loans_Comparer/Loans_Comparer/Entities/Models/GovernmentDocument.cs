using Loans_Comparer.Entities.Enums;

namespace Loans_Comparer.Entities.Models
{
    public class GovernmentDocument
    {
        public GovernmentDocumentTypes typeId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string number { get; set; }
    }
}
