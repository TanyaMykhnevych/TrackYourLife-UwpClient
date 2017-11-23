using UwpClientApp.Data.Entities.OrganRequests;
using UwpClientApp.Presentation.Enums;
using UwpClientApp.Presentation.Models.DonorRequests;
using UwpClientApp.Presentation.Models.OrganInfos;
using UwpClientApp.Presentation.Models.UserInfo;

namespace UwpClientApp.Presentation.Models.PatientRequests
{
    public class PatientRequestDetailsModel
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public PatientRequestStatuses Status { get; set; }

        public int? PatientInfoId { get; set; }
        public UserInfoDetailedModel PatientInfo { get; set; }

        public int OrganInfoId { get; set; }
        public OrganInfoDetailsModel OrganInfo { get; set; }

        public DonorRequestDetailsModel DonorRequest { get; set; }
    }
}