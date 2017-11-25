using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp.UI.Controls;
using ReactiveUI;
using UwpClientApp.Business.Services;
using UwpClientApp.Presentation.Models.DonorRequests;

namespace UwpClientApp.Presentation.ViewModels.DonorRequest
{
    public class DonorRequestListViewModel : ViewModelBase
    {
        private readonly IDonorRequestService _donorRequestService;
        private ReactiveList<DonorRequestListItemModel> _donorRequestList;
        private DonorRequestListItemModel _selectedItem;

        public DonorRequestListViewModel(IDonorRequestService donorRequestService)
        {
            _donorRequestService = donorRequestService;

            Init();
        }

        private async void Init()
        {
            await LoadDonorRequestListAsync();
        }

        public Func<object, object> MapListItemToDetails => x => new DonorRequestDetailsViewModel(x);

        public DonorRequestListItemModel SelectedItem
        {
            get => _selectedItem;
            set => this.RaiseAndSetIfChanged(ref _selectedItem, value);
        }

        public MasterDetailsViewState CurrentViewState { get; set; }

        public ReactiveList<DonorRequestListItemModel> DonorRequestList
        {
            get => _donorRequestList;
            set => this.RaiseAndSetIfChanged(ref _donorRequestList, value);
        }

        private async Task LoadDonorRequestListAsync()
        {
            OnIsInProgressChanges(true);
            try
            {
                var donorRequestsResponse = await _donorRequestService.GetDonorRequestListAsync();

                if (!donorRequestsResponse.IsValid)
                {
                    await ShowErrorAsync(string.IsNullOrEmpty(donorRequestsResponse.ErrorMessage)
                        ? "Load Donor Request List Failed."
                        : donorRequestsResponse.ErrorMessage);
                    return;
                }

                DonorRequestList =
                    new ReactiveList<DonorRequestListItemModel>(donorRequestsResponse.Content.DonorRequestList);
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
