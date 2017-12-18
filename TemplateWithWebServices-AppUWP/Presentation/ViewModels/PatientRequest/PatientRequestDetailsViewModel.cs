using System;
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
        
        private ReactiveCommand _cancelRequestCommentCommand;
        private ReactiveCommand _editRequestCommentCommand;
        private ReactiveCommand _saveRequestCommentCommand;
        private Visibility _editSectionVisibility;
        private Visibility _viewSectionVisibility;

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

        public ReactiveCommand CancelRequestCommentCommand
        {
            get { return _cancelRequestCommentCommand; }
            set { this.RaiseAndSetIfChanged(ref _cancelRequestCommentCommand, value); }
        }

        public ReactiveCommand EditRequestCommentCommand
        {
            get { return _editRequestCommentCommand; }
            set { this.RaiseAndSetIfChanged(ref _editRequestCommentCommand, value); }
        }

        public ReactiveCommand SaveRequestCommentCommand
        {
            get { return _saveRequestCommentCommand; }
            set { this.RaiseAndSetIfChanged(ref _saveRequestCommentCommand, value); }
        }

        public Visibility EditSectionVisibility
        {
            get { return _editSectionVisibility; }
            set { this.RaiseAndSetIfChanged(ref _editSectionVisibility, value); }
        }

        public Visibility ViewSectionVisibility
        {
            get { return _viewSectionVisibility; }
            set { this.RaiseAndSetIfChanged(ref _viewSectionVisibility, value); }
        }

        public ReactiveCommand LoadOrganStateSnapshotsCommand
        {
            get { return _loadOrganStateSnapshotsCommand; }
            set { this.RaiseAndSetIfChanged(ref _loadOrganStateSnapshotsCommand, value); }
        }

        private async void Init()
        {
            await LoadPatientRequestDetailsAsync();
            GoToViewMode();

            LoadOrganStateSnapshotsCommand = ReactiveCommand.CreateFromTask(LoadOrganStateSnapshotsAsync);

            SaveRequestCommentCommand = ReactiveCommand.CreateFromTask(SaveRequestCommentExecutedAsync);
            EditRequestCommentCommand = ReactiveCommand.Create(GoToEditMode);
            CancelRequestCommentCommand = ReactiveCommand.Create(GoToViewMode);

            DonorVisibility = _detailsModel?.DonorRequest != null ? Visibility.Visible : Visibility.Collapsed;

            OrganStatesButtonVisibility =
                Details.Status != PatientRequestStatuses.AwaitingForDonor
                ? Visibility.Visible
                : Visibility.Collapsed;
            OrganStatesVisibility = Visibility.Collapsed;
        }

        private EditPatientRequestModel _editableModel;
        public EditPatientRequestModel EditableModel
        {
            get { return _editableModel; }
            set { this.RaiseAndSetIfChanged(ref _editableModel, value); }
        }

        private void GoToEditMode()
        {
            EditSectionVisibility = Visibility.Visible;
            ViewSectionVisibility = Visibility.Collapsed;

            EditableModel = new EditPatientRequestModel(Details);
        }

        private void GoToViewMode()
        {
            EditSectionVisibility = Visibility.Collapsed;
            ViewSectionVisibility = Visibility.Visible;
        }

        private async Task SaveRequestCommentExecutedAsync()
        {
            if (EditableModel != null && !String.IsNullOrEmpty(Details.Message))
            {
                await UpdateRequestAsync(EditableModel);
                await LoadPatientRequestDetailsAsync();
            }

            GoToViewMode();
        }

        private async Task UpdateRequestAsync(EditPatientRequestModel model)
        {
            OnIsInProgressChanges(true);

            try
            {
                var response = await _patientRequestService.UpdatePatientRequestAsync(model);

                if (!response.IsValid)
                {
                    await ShowErrorAsync(string.IsNullOrEmpty(response.ErrorMessage)
                        ? "Saving Patient Request Message Failed."
                        : response.ErrorMessage);
                }
            }
            catch(Exception ex)
            {
                //TODO: Do nothing 
            }
            finally
            {
                OnIsInProgressChanges(false);
            }
        }


        private async Task LoadPatientRequestDetailsAsync()
        {
            OnIsInProgressChanges(true);

            try
            {
                var patientRequestResponse = await _patientRequestService.GetPatientRequestDetailsAsync(_listItem.Id);

                if (!patientRequestResponse.IsValid)
                {
                    await ShowErrorAsync(string.IsNullOrEmpty(patientRequestResponse.ErrorMessage)
                        ? "Load Patient Request Failed."
                        : patientRequestResponse.ErrorMessage);
                    return;
                }

                Details = patientRequestResponse.Content;
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
