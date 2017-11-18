using System;
using System.Linq;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ReactiveUI;
using UwpClientApp.Business.Services;
using UwpClientApp.Presentation.Constants;
using UwpClientApp.Presentation.Views.LoginPage;
using UwpClientApp.Presentation.Views.MenuPage;
using UwpClientApp.Presentation.Views.MenuPage.Donor;
using UwpClientApp.Presentation.Views.MenuPage.Patient;

namespace UwpClientApp.Presentation.ViewModels
{
    public class MenuContentViewModel : ViewModelBase
    {
        private readonly IPreferencesService _preferencesService;

        private bool _isPaneOpened;
        private MenuItemViewModel _selectedMenuItem;
        private Type _currentPage;

        public MenuContentViewModel(IPreferencesService preferencesService)
        {
            _preferencesService = preferencesService;

            OpenClosePaneCommand = ReactiveCommand.Create(OpenClosePaneCommandExecuted);

            this.ObservableForProperty(x => x.SelectedMenuItem)
                .Subscribe(args => OnSelectedMenuItemChanged(args.Value));

            FillMenuItems();
            SelectedMenuItem = MenuItems.First();
        }

        public ReactiveList<MenuItemViewModel> MenuItems { get; set; } = new ReactiveList<MenuItemViewModel>();

        public Type CurrentPage
        {
            get => _currentPage;
            set => this.RaiseAndSetIfChanged(ref _currentPage, value);
        }

        public MenuItemViewModel SelectedMenuItem
        {
            get => _selectedMenuItem;
            set => this.RaiseAndSetIfChanged(ref _selectedMenuItem, value);
        }

        public bool IsPaneOpened
        {
            get => _isPaneOpened;
            set => this.RaiseAndSetIfChanged(ref _isPaneOpened, value);
        }

        public ReactiveCommand OpenClosePaneCommand { get; }


        public void OnSelectedMenuItemChanged(MenuItemViewModel item)
        {
            if (item.PageType != typeof(LoginPage))
            {
                CurrentPage = item.PageType;
            }
            else
            {
                var frame = (Window.Current.Content as Frame);
                frame?.Navigate(item.PageType);
                _preferencesService.Clear();
            }
            IsPaneOpened = false;
        }

        private void FillMenuItems()
        {
            string userRole = _preferencesService.UserInfo?.RoleName;

            MenuItems.Add(new MenuItemViewModel
            {
                DisplayName = "First Main - Default Empty Page",
                Icon = "\xE80F",
                PageType = typeof(FirstMainPage)
            });

            if (userRole == RolesConstants.Patient)
            {
                MenuItems.Add(new MenuItemViewModel
                {
                    DisplayName = "Create Recipient Request",
                    Icon = "\xE8FA",
                    PageType = typeof(CreatePatientRequestPage)
                });

                MenuItems.Add(new MenuItemViewModel
                {
                    DisplayName = "My Recipient Requests",
                    Icon = "\xE779",
                    PageType = typeof(PatientRequestListPage)
                });
            }
            else if(userRole == RolesConstants.Donor)
            {
                MenuItems.Add(new MenuItemViewModel
                {
                    DisplayName = "Create Donor Request",
                    Icon = "\xE710",
                    PageType = typeof(CreateDonorRequestPage)
                });

                MenuItems.Add(new MenuItemViewModel
                {
                    DisplayName = "My Donor Requests",
                    Icon = "\xE133",
                    PageType = typeof(DonorRequestListPage)
                });
            }

            MenuItems.Add(new MenuItemViewModel
            {
                DisplayName = "Logout",
                Icon = "\xE8F8",
                PageType = typeof(LoginPage)
            });
        }

        private void OpenClosePaneCommandExecuted()
        {
            IsPaneOpened = !IsPaneOpened;
        }
    }

    public class MenuItemViewModel : ReactiveObject
    {
        public string DisplayName { get; set; }

        public string Icon { get; set; }

        public Type PageType { get; set; }
    }
}
