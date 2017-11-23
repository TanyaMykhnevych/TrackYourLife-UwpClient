using System.Threading.Tasks;
using UwpClientApp.Presentation.Models;
using UwpClientApp.Presentation.Models.DonorRequests;

namespace UwpClientApp.Data.Api.APIs
{
    public interface IDonorRequestRestApi
    {
        Task<ResponseWrapper<DonorRequestListModel>> GetDonorRequestListAsync();
    }
}