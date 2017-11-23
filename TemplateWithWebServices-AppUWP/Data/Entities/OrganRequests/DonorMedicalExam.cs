﻿using System;
using UwpClientApp.Data.Entities.Base;
using UwpClientApp.Presentation.Enums;

namespace UwpClientApp.Data.Entities.OrganRequests
{
    public class DonorMedicalExam : BaseEntity
    {
        public int Id { get; set; }

        public DateTime ScheduledAt { get; set; }

        /// <summary>
        /// Where examination will be passed
        /// </summary>
        public int ClinicId { get; set; }

        public Clinic Clinic { get; set; }

        public MedicalExamStatuses Status { get; set; }

        public string Results { get; set; }

        public int DonorRequestId { get; set; }
        public DonorRequest DonorRequest { get; set; }
    }
}