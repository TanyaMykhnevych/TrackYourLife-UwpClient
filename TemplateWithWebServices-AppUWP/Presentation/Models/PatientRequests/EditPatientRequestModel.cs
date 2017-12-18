using System;

namespace UwpClientApp.Presentation.Models.PatientRequests
{
    public class EditPatientRequestModel
    {
        public int PatientRequestId { get; set; }
        
        public string PatientPhoneNumber { get; set; }

        public string PatientAddressLine1 { get; set; }

        public string Message { get; set; }

        public EditPatientRequestModel(PatientRequestDetailsModel model)
        {
            PatientRequestId = model.Id;
            PatientPhoneNumber = model.PatientInfo.PhoneNumber;
            PatientAddressLine1 = model.PatientInfo.AddressLine1;
            Message = model.Message;
        }
    }
}
