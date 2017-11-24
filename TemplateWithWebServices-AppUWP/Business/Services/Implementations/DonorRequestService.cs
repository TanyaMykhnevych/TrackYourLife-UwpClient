using System.Threading.Tasks;
using UwpClientApp.Data.Api.APIs;
using UwpClientApp.Presentation.Models;
using UwpClientApp.Presentation.Models.DonorRequests;

namespace UwpClientApp.Business.Services.Implementations
{
    internal class DonorRequestService : IDonorRequestService
    {
        private readonly IDonorRequestRestApi _requestRestApi;

        public DonorRequestService(IDonorRequestRestApi requestRestApi)
        {
            _requestRestApi = requestRestApi;
        }


        public async Task<ResponseWrapper<DonorRequestListModel>> GetDonorRequestListAsync()
        {
            return await _requestRestApi.GetDonorRequestListAsync();
        }

        public async Task<ResponseWrapper<DonorRequestDetailsModel>> GetDonorRequestDetailsAsync(int donorRequestId)
        {
            return await _requestRestApi.GetDonorRequestDetailsAsync(donorRequestId);
        }
    }
}
