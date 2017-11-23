using System.Threading.Tasks;
using UwpClientApp.Presentation.Models;
using UwpClientApp.Presentation.Models.DonorRequests;

namespace UwpClientApp.Business.Services
{
    public interface IDonorRequestService
    {
        Task<ResponseWrapper<DonorRequestListModel>> GetDonorRequestListAsync();
    }
}
