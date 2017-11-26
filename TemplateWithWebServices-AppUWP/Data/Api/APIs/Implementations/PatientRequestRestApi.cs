using System;
using System.Threading.Tasks;
using UwpClientApp.Data.Api.Rest;
using UwpClientApp.Presentation.Models;
using UwpClientApp.Presentation.Models.PatientRequests;

namespace UwpClientApp.Data.Api.APIs.Implementations
{
    public class PatientRequestRestApi : RestApiBase, IPatientRequestRestApi
    {
        private const string BaseApiAddress = ApiRouting.BaseApiUrl;

        public PatientRequestRestApi() : base(new Uri(BaseApiAddress))
        {
        }

        public async Task<ResponseWrapper<PatientRequestDetailsModel>> GetPatientRequestDetailsAsync(int patientRequestId)
        {
            var response = await Url($"patientRequest/getPatientRequestDetails/{patientRequestId}")
               .GetAsync<ResponseWrapper<PatientRequestDetailsModel>>();
            return response;
        }

        public async Task<ResponseWrapper<PatientRequestListModel>> GetPatientRequestListAsync()
        {
             var response = await Url("patientRequest/getPatientRequestList")
                    .GetAsync<ResponseWrapper<PatientRequestListModel>>();
            return response;
        }
    }
}
