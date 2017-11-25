using UwpClientApp.Presentation.Enums;

namespace UwpClientApp.Presentation.Models.PatientRequests
{
    public class PatientRequestListItemModel
    {
        public int Id { get; set; }

        public string PatientFullName { get; set; }

        public string Message { get; set; }
        
        public PatientRequestStatuses Status { get; set; }

        public PatientRequestPriority Priority { get; set; }

        public int? PatientInfoId { get; set; }

        public int OrganInfoId { get; set; }

        public string OrganInfoName { get; set; }
        
        public bool HasLinkedDonorRequest { get; set; }
    }
}
