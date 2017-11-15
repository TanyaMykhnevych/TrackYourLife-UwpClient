﻿using System;
using System.Linq;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ReactiveUI;
using UwpClientApp.Business.Services;
using UwpClientApp.Presentation.Views.LoginPage;
using UwpClientApp.Presentation.Views.MenuPage.MainPage;
using UwpClientApp.Presentation.Views.MenuPage.Test1Page;
using UwpClientApp.Presentation.Views.MenuPage.Test2Page;

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
            MenuItems.Add(new MenuItemViewModel()
            {
                DisplayName = "MainPage",
                Icon = "\xEE57",
                PageType = typeof(MainPage)
            });
            MenuItems.Add(new MenuItemViewModel()
            {
                DisplayName = "Test1Page",
                Icon = "\xE779",
                PageType = typeof(Test1Page)
            });
            MenuItems.Add(new MenuItemViewModel()
            {
                DisplayName = "Test2Page",
                Icon = "\xEE92",
                PageType = typeof(Test2Page)
            });
            MenuItems.Add(new MenuItemViewModel()
            {
                DisplayName = "Test2Page",
                Icon = "\xE716",
                PageType = typeof(Test2Page)
            });
            MenuItems.Add(new MenuItemViewModel()
            {
                DisplayName = "Logout",
                Icon = "\xE716",
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
