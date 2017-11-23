﻿using System;
using System.Collections.Generic;
using UwpClientApp.Data.Entities.Base;
using UwpClientApp.Data.Entities.Organ;
using UwpClientApp.Presentation.Enums;

namespace UwpClientApp.Data.Entities.OrganDelivery
{
    public class OrganDeliveryInfo : BaseEntity
    {
        public int Id { get; set; }

        public DateTime StartTransportTime { get; set; }
        
        public OrganDeliveryStatuses Status { get; set; }

        public int TransplantOrganId { get; set; }
        public TransplantOrgan TransplantOrgan { get; set; }

        public int FromClinicId { get; set; }
        public virtual Clinic FromClinic { get; set; }

        public int ToClinicId { get; set; }
        public virtual Clinic ToClinic { get; set; }

        public int DonorId { get; set; }
        public virtual UserInfo Donor { get; set; }

        public int PatientId { get; set; }
        public virtual UserInfo Patient { get; set; }

        public virtual ICollection<OrganDataSnapshot> OrganDataSnapshots { get; set; }
    }
}
