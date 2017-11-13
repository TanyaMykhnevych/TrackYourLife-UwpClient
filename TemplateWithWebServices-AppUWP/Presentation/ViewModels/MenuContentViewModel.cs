using System;
using System.Linq;
using ReactiveUI;

namespace UwpClientApp.Presentation.ViewModels
{
    public class MenuContentViewModel : ViewModelBase
    {
        private bool _isPaneOpened;
        private MenuItemViewModel _selectedMenuItem;

        public MenuContentViewModel()
        {
            OpenClosePaneCommand = ReactiveCommand.Create(OpenClosePaneCommandExecuted);

            this.ObservableForProperty(x => x.SelectedMenuItem)
                .Subscribe(args => OnSelectedMenuItemChanged(args.Value));

            FillMenuItems();
            SelectedMenuItem = MenuItems.First();
        }

        public ReactiveList<MenuItemViewModel> MenuItems { get; set; } = new ReactiveList<MenuItemViewModel>();

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
            
        }

        private void FillMenuItems()
        {
            MenuItems.Add(new MenuItemViewModel()
            {
                DisplayName = "Login",
                Icon = "\xE825"
            });
            MenuItems.Add(new MenuItemViewModel()
            {
                DisplayName = "Profile",
                Icon = "\xE1D6"
            });
            MenuItems.Add(new MenuItemViewModel()
            {
                DisplayName = "Donor Requests",
                Icon = "\xE10F"
            });
            MenuItems.Add(new MenuItemViewModel()
            {
                DisplayName = "Patient Requests",
                Icon = "\xE1D6"
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
