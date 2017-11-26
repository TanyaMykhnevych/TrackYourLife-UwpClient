﻿using System.Threading.Tasks;
using UwpClientApp.Presentation.Models;
using UwpClientApp.Presentation.Models.PatientRequests;

namespace UwpClientApp.Business.Services
{
    public interface IPatientRequestService
    {
        Task<ResponseWrapper<PatientRequestListModel>> GetPatientRequestListAsync();

        Task<ResponseWrapper<PatientRequestDetailsModel>> GetPatientRequestDetailsAsync(int patientRequestId);
    }
}
