using Autofac;
using ReactiveUI;
using System.Threading.Tasks;
using UwpClientApp.Business.Services;
using UwpClientApp.Presentation.Models.PatientRequests;
using Windows.UI.Xaml;

namespace UwpClientApp.Presentation.ViewModels.PatientRequest
{
    public class PatientRequestDetailsViewModel : ViewModelBase
    {
        private readonly IPatientRequestService _patientRequestService;

        private readonly PatientRequestListItemModel _listItem;
        private PatientRequestDetailsModel _detailsModel;
        private Visibility _clinicVisibility;

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
        

        public Visibility ClinicVisibility
        {
            get { return _clinicVisibility; }
            set { this.RaiseAndSetIfChanged(ref _clinicVisibility, value); }
        }

        private async void Init()
        {
            Details = await LoadPatientRequestDetailsAsync();
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
