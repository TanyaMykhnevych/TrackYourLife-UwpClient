using Microsoft.Toolkit.Uwp.UI.Controls;
using ReactiveUI;
using System;
using System.Threading.Tasks;
using UwpClientApp.Business.Services;
using UwpClientApp.Presentation.Models.PatientRequests;

namespace UwpClientApp.Presentation.ViewModels.PatientRequest
{
    public class PatientRequestListViewModel : ViewModelBase
    {
        private readonly IPatientRequestService _patientRequestService;
        private ReactiveList<PatientRequestListItemModel> _patientRequestList;
        private PatientRequestListItemModel _selectedItem;

        public PatientRequestListViewModel(IPatientRequestService patientRequestService)
        {
            _patientRequestService = patientRequestService;

            Init();
        }

        private async void Init()
        {
            await LoadPatientRequestListAsync();
        }

        public Func<object, object> MapListItemToDetails => x => new PatientRequestDetailsViewModel(x);

        public PatientRequestListItemModel SelectedItem
        {
            get => _selectedItem;
            set => this.RaiseAndSetIfChanged(ref _selectedItem, value);
        }

        public MasterDetailsViewState CurrentViewState { get; set; }

        public ReactiveList<PatientRequestListItemModel> PatientRequestList
        {
            get => _patientRequestList;
            set => this.RaiseAndSetIfChanged(ref _patientRequestList, value);
        }

        private async Task LoadPatientRequestListAsync()
        {
            OnIsInProgressChanges(true);
            try
            {
                var patientRequestsResponse = await _patientRequestService.GetPatientRequestListAsync();

                if (!patientRequestsResponse.IsValid)
                {
                    await ShowErrorAsync(string.IsNullOrEmpty(patientRequestsResponse.ErrorMessage)
                        ? "Load Patient Request List Failed."
                        : patientRequestsResponse.ErrorMessage);
                    return;
                }

                PatientRequestList =
                    new ReactiveList<PatientRequestListItemModel>(patientRequestsResponse.Content.PatientRequestList);
            }
            catch
            {
                //TODO: Do nothing 
            }
            finally
            {
                OnIsInProgressChanges(false);
            }
        }
    }
}
