using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Autofac;
using ReactiveUI;
using UwpClientApp.Business.Services;
using Windows.UI.Xaml;
using UwpClientApp.Presentation.Models.PatientRequests;

namespace UwpClientApp.Presentation.ViewModels.PatientRequest
{
    public class PatientRequestDetailsViewModel : ViewModelBase
    {
        private readonly IPatientRequestService _patientRequestService;

        private readonly PatientRequestListItemModel _listItem;
        private PatientRequestDetailsModel _detailsModel;
        private Visibility _donorVisibility;

        public PatientRequestDetailsViewModel(object patientListItem)
        {
            _listItem = patientListItem as PatientRequestListItemModel;
            _patientRequestService = App.Container.Resolve<IPatientRequestService>();

            Init();
        }

        public PatientRequestDetailsModel Details
        {
            get => _detailsModel;
            set => this.RaiseAndSetIfChanged(ref _detailsModel, value);
        }

        public Visibility DonorVisibility
        {
            get { return _donorVisibility; }
            set { this.RaiseAndSetIfChanged(ref _donorVisibility, value); }
        }

        private async void Init()
        {
            Details = await LoadPatientRequestDetailsAsync();

            DonorVisibility = _detailsModel?.DonorRequest != null ? Visibility.Visible : Visibility.Collapsed;
        }

        private async Task<PatientRequestDetailsModel> LoadPatientRequestDetailsAsync()
        {
            PatientRequestDetailsModel result = null;
            OnIsInProgressChanges(true);

            try
            {
                var patientRequestResponse = await _patientRequestService.GetPatientRequestDetailsAsync(_listItem.Id);

                if (!patientRequestResponse.IsValid)
                {
                    await ShowErrorAsync(string.IsNullOrEmpty(patientRequestResponse.ErrorMessage)
                        ? "Load Patient Request Failed."
                        : patientRequestResponse.ErrorMessage);
                    return null;
                }

                result = patientRequestResponse.Content;
            }
            catch
            {
                //TODO: Do nothing 
            }
            finally
            {
                OnIsInProgressChanges(false);
            }

            return result;
        }
    }
}
