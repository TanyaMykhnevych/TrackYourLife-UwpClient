using System.Collections.Generic;
using UwpClientApp.Data.Entities.Base;
using UwpClientApp.Data.Entities.Organ;
using UwpClientApp.Presentation.Enums;

namespace UwpClientApp.Data.Entities.OrganRequests
{
    public class DonorRequest : BaseEntity
    {
        public int Id { get; set; }

        public string Message { get; set; }
        
        public DonorRequestStatuses Status { get; set; }

        public int DonorInfoId { get; set; }
        public UserInfo DonorInfo { get; set; }

        public int OrganInfoId { get; set; }
        public OrganInfo OrganInfo { get; set; }

        public int? TransplantOrganId { get; set; }
        public TransplantOrgan TransplantOrgan { get; set; }
        
        public RequestsRelation RequestsRelation { get; set; }

        public ICollection<DonorMedicalExam> DonorMedicalExams { get; set; }
    }
}
