using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Autofac;
using ReactiveUI;
using UwpClientApp.Business.Services;
using UwpClientApp.Presentation.Models.DonorRequests;
using Windows.UI.Xaml;

namespace UwpClientApp.Presentation.ViewModels.DonorRequest
{
    public class DonorRequestDetailsViewModel : ViewModelBase
    {
        private readonly IDonorRequestService _donorRequestService;

        private readonly DonorRequestListItemModel _listItem;
        private DonorRequestDetailsModel _detailsModel;
        private Visibility _clinicVisibility;
        
        public DonorRequestDetailsViewModel(object donorListItem)
        {
            _listItem = donorListItem as DonorRequestListItemModel;
            _donorRequestService = App.Container.Resolve<IDonorRequestService>();
            this.ObservableForProperty(x => x._detailsModel.MedicalExamClinic).Subscribe(x => ClinicVisibility = x != null ? Visibility.Visible : Visibility.Collapsed);
            Init();
        }

        public DonorRequestDetailsModel Details
        {
            get => _detailsModel;
            set => this.RaiseAndSetIfChanged(ref _detailsModel, value);
        }

        public Boolean IsClinicVisible
        {
            get => _detailsModel?.MedicalExamClinic != null;
        }

        public Visibility ClinicVisibility
        {
            get { return _clinicVisibility; }
            set { this.RaiseAndSetIfChanged(ref _clinicVisibility, value); }
        }

        private async void Init()
        {
            Details = await LoadDonorRequestDetailsAsync();
        }

        private async Task<DonorRequestDetailsModel> LoadDonorRequestDetailsAsync()
        {
            DonorRequestDetailsModel result = null;
            OnIsInProgressChanges(true);

            try
            {
                var donorRequestResponse = await _donorRequestService.GetDonorRequestDetailsAsync(_listItem.Id);

                if (!donorRequestResponse.IsValid)
                {
                    await ShowErrorAsync(string.IsNullOrEmpty(donorRequestResponse.ErrorMessage)
                        ? "Load Donor Request Failed."
                        : donorRequestResponse.ErrorMessage);
                    return null;
                }

                result = donorRequestResponse.Content;
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
