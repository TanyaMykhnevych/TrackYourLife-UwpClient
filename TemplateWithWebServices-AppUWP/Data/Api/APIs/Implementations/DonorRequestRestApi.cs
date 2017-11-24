using System;
using System.Threading.Tasks;
using UwpClientApp.Data.Api.Rest;
using UwpClientApp.Presentation.Models;
using UwpClientApp.Presentation.Models.DonorRequests;

namespace UwpClientApp.Data.Api.APIs.Implementations
{
    public class DonorRequestRestApi : RestApiBase, IDonorRequestRestApi
    {
        private const string BaseApiAddress = ApiRouting.BaseApiUrl;

        public DonorRequestRestApi() : base(new Uri(BaseApiAddress))
        {
        }

        public async Task<ResponseWrapper<DonorRequestListModel>> GetDonorRequestListAsync()
        {
            return await Url("donorRequests/getDonorRequestList")
                .GetAsync<ResponseWrapper<DonorRequestListModel>>();
        }

        public async Task<ResponseWrapper<DonorRequestDetailsModel>> GetDonorRequestDetailsAsync(int donorRequestId)
        {
            return await Url($"donorRequests/getDonorRequestDetails/{donorRequestId}")
                .GetAsync<ResponseWrapper<DonorRequestDetailsModel>>();
            
        }
    }
}