using System;
using Windows.UI.Xaml;
using Autofac;
using ReactiveUI;
using UwpClientApp.Presentation.ViewModels;

namespace UwpClientApp.Presentation.Views.MenuPage
{
    public sealed partial class MenuContentPage : IViewFor<MenuContentViewModel>
    {
        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(MenuContentViewModel), typeof(MenuContentPage), new PropertyMetadata(default(MenuContentViewModel)));

        public MenuContentPage()
        {
            this.InitializeComponent();
            ViewModel = App.Container.Resolve<MenuContentViewModel>();

            this.WhenActivated(CreateBindings);
        }

        private void CreateBindings(Action<IDisposable> d)
        {
            d(this.OneWayBind(ViewModel, vm => vm.SpinnerVisibility, v => v.PreloaderProgressRing.Visibility));
            d(this.OneWayBind(ViewModel, vm => vm.IsPaneOpened, v => v.HamburgerSplitView.IsPaneOpen));
            d(this.BindCommand(ViewModel, vm => vm.OpenClosePaneCommand, v => v.OpenClosePaneButton));

            d(this.OneWayBind(ViewModel, vm => vm.MenuItems, v => v.MenuItemsItemsControl.ItemsSource));
            d(this.Bind(ViewModel, vm => vm.SelectedMenuItem, v => v.MenuItemsItemsControl.SelectedItem));

            d(this.Bind(ViewModel, vm => vm.CurrentPage, v => v.AppMenuInternalFrame.SourcePageType));
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (MenuContentViewModel)value;
        }

        public MenuContentViewModel ViewModel
        {
            get => (MenuContentViewModel) GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }
    }
}
