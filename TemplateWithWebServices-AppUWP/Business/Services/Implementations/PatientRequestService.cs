using System.Collections.Generic;
using System.Threading.Tasks;
using UwpClientApp.Data.Api.APIs;
using UwpClientApp.Presentation.Models;
using UwpClientApp.Presentation.Models.PatientRequests;

namespace UwpClientApp.Business.Services.Implementations
{
    internal class PatientRequestService : IPatientRequestService
    {
        private readonly IPatientRequestRestApi _requestRestApi;

        public PatientRequestService(IPatientRequestRestApi requestRestApi)
        {
            _requestRestApi = requestRestApi;
        }

        public async Task<ResponseWrapper<PatientRequestDetailsModel>> GetPatientRequestDetailsAsync(int patientRequestId)
        {
            return await _requestRestApi.GetPatientRequestDetailsAsync(patientRequestId);
        }

        public async Task<ResponseWrapper<PatientRequestListModel>> GetPatientRequestListAsync()
        {
            return await _requestRestApi.GetPatientRequestListAsync();
        }

        public async Task<ResponseWrapper<IList<OrganStateSnapshotModel>>> GetOrganStateSnapshotListAsync(int patientRequestId)
        {
            return await _requestRestApi.GetOrganStateSnapshotListAsync(patientRequestId);
        }
    }
}
