using System;
using UwpClientApp.Presentation.Enums;

namespace UwpClientApp.Presentation.Models.MedicalExam
{
    public class DonorMedicalExamListItemModel
    {
        public int Id { get; set; }

        public DateTime ScheduledAt { get; set; }
        
        public int ClinicId { get; set; }

        public MedicalExamStatuses Status { get; set; }

        public string Results { get; set; }

        public int DonorRequestId { get; set; }
    }
}
