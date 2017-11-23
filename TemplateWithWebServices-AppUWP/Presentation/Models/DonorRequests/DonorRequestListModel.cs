using System.Collections.Generic;

namespace UwpClientApp.Presentation.Models.DonorRequests
{
    public class DonorRequestListModel
    {
        public ICollection<DonorRequestListItemModel> DonorRequestList { get; set; }
    }
}