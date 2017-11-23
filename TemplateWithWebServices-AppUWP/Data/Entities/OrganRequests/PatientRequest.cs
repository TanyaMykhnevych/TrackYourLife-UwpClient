﻿using UwpClientApp.Data.Entities.Base;
using UwpClientApp.Data.Entities.Organ;
using UwpClientApp.Presentation.Enums;

namespace UwpClientApp.Data.Entities.OrganRequests
{
    public class PatientRequest : BaseEntity
    {
        public int Id { get; set; }

        public string Message { get; set; }
        
        public PatientRequestStatuses Status { get; set; }
        
        public PatientRequestPriority Priority { get; set; }

        public int? PatientInfoId { get; set; }
        public UserInfo PatientInfo { get; set; }

        public int OrganInfoId { get; set; }
        public OrganInfo OrganInfo { get; set; }
        
        public RequestsRelation RequestsRelation { get; set; }
    }
}
