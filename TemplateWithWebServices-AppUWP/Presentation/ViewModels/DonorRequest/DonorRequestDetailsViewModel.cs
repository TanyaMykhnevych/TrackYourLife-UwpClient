using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ReactiveUI;
using UwpClientApp.Business.Services;
using UwpClientApp.Presentation.Models.DonorRequests;

namespace UwpClientApp.Presentation.ViewModels.DonorRequest
{
    public class DonorRequestDetailsViewModel : ViewModelBase
    {
        private readonly IDonorRequestService _donorRequestService;

        private readonly DonorRequestListItemModel _listItem;
        private DonorRequestDetailsModel _detailsModel;

        public DonorRequestDetailsViewModel(object donorListItem)
        {
            _listItem = donorListItem as DonorRequestListItemModel;
            _donorRequestService = App.Container.Resolve<IDonorRequestService>();

            Init();
        }

        public DonorRequestDetailsModel Details
        {
            get => _detailsModel;
            set => this.RaiseAndSetIfChanged(ref _detailsModel, value);
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
