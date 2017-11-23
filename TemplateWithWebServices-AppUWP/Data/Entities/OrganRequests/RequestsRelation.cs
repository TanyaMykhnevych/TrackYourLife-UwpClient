using UwpClientApp.Data.Entities.Base;

namespace UwpClientApp.Data.Entities.OrganRequests
{
    public class RequestsRelation : BaseEntity
    {
        public int Id { get; set; }

        public int DonorRequestId { get; set; }
        public DonorRequest DonorRequest { get; set; }
        
        public int PatientRequestId { get; set; }
        public PatientRequest PatientRequest { get; set; }

        public bool IsActive { get; set; }
    }
}
