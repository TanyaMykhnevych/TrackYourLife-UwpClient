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
        private DonorRequestDetailsModel _selectedDetailsItem;

        public DonorRequestListViewModel(IDonorRequestService donorRequestService)
        {
            _donorRequestService = donorRequestService;

            Init();
        }

        private async void Init()
        {
            await LoadDonorRequestListAsync();

            this.ObservableForProperty(x => x.SelectedItem).Subscribe(async args =>
            {
                SelectedDetailsItem = await LoadDonorRequestDetailsAsync(args.Value);
            });
        }

        public Func<object, object> MapListItemToDetails => x => SelectedDetailsItem;

        public DonorRequestListItemModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (value != null)
                {
                    UpdateDetails(value);
                }

                this.RaiseAndSetIfChanged(ref _selectedItem, value);
            }
        }

        public DonorRequestDetailsModel SelectedDetailsItem
        {
            get => _selectedDetailsItem;
            set => this.RaiseAndSetIfChanged(ref _selectedDetailsItem, value);
        }

        public MasterDetailsViewState CurrentViewState { get; set; }

        public ReactiveList<DonorRequestListItemModel> DonorRequestList
        {
            get => _donorRequestList;
            set => this.RaiseAndSetIfChanged(ref _donorRequestList, value);
        }

        private async void UpdateDetails(DonorRequestListItemModel listItem)
        {
            SelectedDetailsItem = await LoadDonorRequestDetailsAsync(listItem);
        }
        
        private async Task<DonorRequestDetailsModel> LoadDonorRequestDetailsAsync(DonorRequestListItemModel listItem)
        {
            DonorRequestDetailsModel result = null;

            try
            {
                var donorRequestResponse = await _donorRequestService.GetDonorRequestDetailsAsync(listItem.Id);

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
            { //TODO: Do nothing 
            }

            return result;
        }

        private async Task LoadDonorRequestListAsync()
        {
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

                DonorRequestList = new ReactiveList<DonorRequestListItemModel>(donorRequestsResponse.Content.DonorRequestList.ToList());
            }
            catch
            { //TODO: Do nothing 
            }
        }
    }
}
