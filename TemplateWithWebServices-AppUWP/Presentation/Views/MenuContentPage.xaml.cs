using System;
using Windows.UI.Xaml;
using ReactiveUI;
using UwpClientApp.Presentation.ViewModels;

namespace UwpClientApp.Presentation.Views
{
    public sealed partial class MenuContentPage : IViewFor<MenuContentViewModel>
    {
        public MenuContentPage()
        {
            this.InitializeComponent();
            this.WhenActivated(CreateBindings);
        }

        private void CreateBindings(Action<IDisposable> d)
        {
            d(this.OneWayBind(ViewModel, vm => vm.IsPaneOpened, v => v.HamburgerSplitView.IsPaneOpen));
            d(this.BindCommand(ViewModel, vm => vm.OpenClosePaneCommand, v => v.OpenClosePaneButton));
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (MenuContentViewModel)value;
        }

        public MenuContentViewModel ViewModel { get; set; }
    }
}
