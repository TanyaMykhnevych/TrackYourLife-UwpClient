using System.Collections.Generic;

namespace UwpClientApp.Presentation.Models.PatientRequests
{
    public class PatientRequestListModel
    {
        public ICollection<PatientRequestListItemModel> PatientRequestList { get; set; }
    }
}
