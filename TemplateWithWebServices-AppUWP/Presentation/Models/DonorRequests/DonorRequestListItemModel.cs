using UwpClientApp.Presentation.Enums;
using UwpClientApp.Presentation.Models.MedicalExam;

namespace UwpClientApp.Presentation.Models.DonorRequests
{
    public class DonorRequestListItemModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Message { get; set; }

        public DonorRequestStatuses Status { get; set; }

        public int DonorInfoId { get; set; }

        public int OrganInfoId { get; set; }

        public string OrganInfoName { get; set; }

        public bool HasLinkedPatientRequest { get; set; }

        public int MedicalExamsCount { get; set; }

        public DonorMedicalExamListItemModel LastMedicalExam { get; set; }
    }
}