using UwpClientApp.Data.Entities.Base;
using UwpClientApp.Data.Entities.OrganDelivery;
using UwpClientApp.Data.Entities.OrganRequests;
using UwpClientApp.Presentation.Enums;

namespace UwpClientApp.Data.Entities.Organ
{
    public class TransplantOrgan : BaseEntity
    {
        public int Id { get; set; }

        public string AdditionalInfo { get; set; }
        
        public TransplantOrganStatuses Status { get; set; }

        public int UserInfoId { get; set; }
        public virtual UserInfo UserInfo { get; set; }
        
        public virtual DonorRequest DonorRequest { get; set; }

        public int OrganInfoId { get; set; }
        public OrganInfo OrganInfo { get; set; }

        public int? OrganDeliveryInfoId { get; set; }
        public virtual OrganDeliveryInfo OrganDeliveryInfo { get; set; }

        public int ClinicId { get; set; }
        public virtual Clinic Clinic { get; set; }
    }
}
