﻿using System;
using System.Collections.Generic;
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

        public async Task<ResponseWrapper<IList<OrganStateSnapshotModel>>> GetOrganStateSnapshotListAsync(int patientRequestId)
        {
            var response = await Url($"organDelivery/getOrganDeliverySnapshot/{patientRequestId}")
                   .GetAsync<ResponseWrapper<IList<OrganStateSnapshotModel>>>();
            return response;
        }

        public Task<ResponseWrapper> UpdatePatientRequestAsync(EditPatientRequestModel model)
        {
            return Url("patientRequest/updatePatientRequest")
                .FormUrlEncoded()
                .Param(nameof(model.PatientRequestId), model.PatientRequestId.ToString())
                .Param(nameof(model.Message), model.Message)
                .Param(nameof(model.PatientPhoneNumber), model.PatientPhoneNumber)
                .Param(nameof(model.PatientAddressLine1), model.PatientAddressLine1)
                .PostAsync<ResponseWrapper>();
        }
    }
}
