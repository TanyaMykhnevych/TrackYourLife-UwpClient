using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Autofac;
using ReactiveUI;
using UwpClientApp.Business.Services;
using Windows.UI.Xaml;
using UwpClientApp.Presentation.Models.PatientRequests;
using System.Threading;
using UwpClientApp.Presentation.Enums;

namespace UwpClientApp.Presentation.ViewModels.PatientRequest
{
    public class PatientRequestDetailsViewModel : ViewModelBase
    {
        private readonly IPatientRequestService _patientRequestService;
        private readonly PatientRequestListItemModel _listItem;

        private PatientRequestDetailsModel _detailsModel;
        private ReactiveList<OrganStateSnapshotModel> _organStatesModel;
        private Visibility _donorVisibility;
        private Visibility _organStatesVisibility;
        private Visibility _organStatesButtonVisibility;
        private ReactiveCommand _loadOrganStateSnapshotsCommand;

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

        public ReactiveList<OrganStateSnapshotModel> OrganStates
        {
            get => _organStatesModel;
            set => this.RaiseAndSetIfChanged(ref _organStatesModel, value);
        }

        public Visibility DonorVisibility
        {
            get { return _donorVisibility; }
            set { this.RaiseAndSetIfChanged(ref _donorVisibility, value); }
        }

        public Visibility OrganStatesVisibility
        {
            get { return _organStatesVisibility; }
            set { this.RaiseAndSetIfChanged(ref _organStatesVisibility, value); }
        }

        public Visibility OrganStatesButtonVisibility
        {
            get { return _organStatesButtonVisibility; }
            set { this.RaiseAndSetIfChanged(ref _organStatesButtonVisibility, value); }
        }

        public ReactiveCommand LoadOrganStateSnapshotsCommand
        {
            get { return _loadOrganStateSnapshotsCommand; }
            set { this.RaiseAndSetIfChanged(ref _loadOrganStateSnapshotsCommand, value); }
        }


        private async void Init()
        {
            Details = await LoadPatientRequestDetailsAsync();

            // await LoadOrganStateSnapshotsAsync();

            LoadOrganStateSnapshotsCommand = ReactiveCommand.CreateFromTask(LoadOrganStateSnapshotsAsync);

            DonorVisibility = _detailsModel?.DonorRequest != null ? Visibility.Visible : Visibility.Collapsed;

            OrganStatesButtonVisibility =
                Details.Status != PatientRequestStatuses.AwaitingForDonor
                ? Visibility.Visible
                : Visibility.Collapsed;
            OrganStatesVisibility = Visibility.Collapsed;

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

        private async Task LoadOrganStateSnapshotsAsync(CancellationToken cancelToken)
        {
            OnIsInProgressChanges(true);

            try
            {
                var patientRequestResponse = await _patientRequestService.GetOrganStateSnapshotListAsync(_listItem.Id);

                if (!patientRequestResponse.IsValid)
                {
                    await ShowErrorAsync(string.IsNullOrEmpty(patientRequestResponse.ErrorMessage)
                        ? "Load Patient Request Failed."
                        : patientRequestResponse.ErrorMessage);
                    return;
                }

                OrganStates = new ReactiveList<OrganStateSnapshotModel>(patientRequestResponse.Content);
                OrganStatesButtonVisibility = Visibility.Collapsed;
                OrganStatesVisibility = Visibility.Visible;
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
