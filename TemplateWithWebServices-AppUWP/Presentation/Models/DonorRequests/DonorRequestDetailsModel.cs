using System.Linq;
using UwpClientApp.Data.Entities.OrganRequests;
using UwpClientApp.Presentation.Enums;
using UwpClientApp.Presentation.Models.Clinics;
using UwpClientApp.Presentation.Models.MedicalExam;
using UwpClientApp.Presentation.Models.OrganInfos;
using UwpClientApp.Presentation.Models.PatientRequests;
using UwpClientApp.Presentation.Models.UserInfo;

namespace UwpClientApp.Presentation.Models.DonorRequests
{
    public class DonorRequestDetailsModel
    {
        public int Id { get; set; }

        public string Message { get; set; }
        
        public DonorRequestStatuses Status { get; set; }

        public int DonorInfoId { get; set; }
        public UserInfoDetailedModel DonorInfo { get; set; }

        public int OrganInfoId { get; set; }
        public OrganInfoDetailsModel OrganInfo { get; set; }
        
        public int? TransplantOrganId { get; set; }
        
        public PatientRequestDetailsModel PatientRequest { get; set; }

        public int MedicalExamsCount { get; set; }

        public DonorMedicalExamListItemModel LastDonorMedicalExam { get; set; }

        public ClinicListItemModel MedicalExamClinic { get; set; }
    }
}
