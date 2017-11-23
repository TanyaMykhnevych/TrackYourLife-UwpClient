using System.Linq;
using ReactiveUI;
using UwpClientApp.Business.Services;
using UwpClientApp.Presentation.Models.DonorRequests;

namespace UwpClientApp.Presentation.ViewModels.DonorRequest
{
    public class DonorRequestListViewModel : ViewModelBase
    {
        private readonly IDonorRequestService _donorRequestService;
        private ReactiveList<DonorRequestListItemModel> _donorRequestList;

        public DonorRequestListViewModel(IDonorRequestService donorRequestService)
        {
            _donorRequestService = donorRequestService;

            LoadDonorRequestListAsync();
        }

        public ReactiveList<DonorRequestListItemModel> DonorRequestList
        {
            get => _donorRequestList;
            set => this.RaiseAndSetIfChanged(ref _donorRequestList, value);
        }

        private void GoToDetails()
        {
            
        }

        private async void LoadDonorRequestListAsync()
        {
            var donorRequestsResponse = await _donorRequestService.GetDonorRequestListAsync();

            if (!donorRequestsResponse.IsValid)
            {
                await ShowErrorAsync(string.IsNullOrEmpty(donorRequestsResponse.ErrorMessage) 
                    ? "Load Donor Request Failed."
                    : donorRequestsResponse.ErrorMessage);
                return;
            }

            DonorRequestList = new ReactiveList<DonorRequestListItemModel>(donorRequestsResponse.Content.DonorRequestList.ToList());
        }
    }
}
