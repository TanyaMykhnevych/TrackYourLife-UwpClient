using System;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;
using Autofac;
using ReactiveUI;
using UwpClientApp.Presentation.ViewModels.DonorRequest;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace UwpClientApp.Presentation.Views.MenuPage.Donor
{
    public sealed partial class DonorRequestListPage : IViewFor<DonorRequestListViewModel>
    {
        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(DonorRequestListViewModel),
                typeof(DonorRequestListPage), new PropertyMetadata(default(DonorRequestListViewModel)));
        
        public DonorRequestListPage()
        {
            InitializeComponent();
            ViewModel = App.Container.Resolve<DonorRequestListViewModel>();

            this.WhenActivated(CreateBindings);
        }

        private void CreateBindings(Action<IDisposable> d)
        {
            //DonorRequestsMasterDetails.NoSelectionContent = new object();

            d(this.OneWayBind(ViewModel, vm => vm.DonorRequestList, v => v.DonorRequestsMasterDetails.ItemsSource));
            d(this.Bind(ViewModel, vm => vm.SelectedItem, v => v.DonorRequestsMasterDetails.SelectedItem));
            d(this.OneWayBind(ViewModel, vm => vm.MapListItemToDetails, v => v.DonorRequestsMasterDetails.MapDetails));
            d(this.Bind(ViewModel, vm => vm.CurrentViewState, v => v.DonorRequestsMasterDetails.ViewState));
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (DonorRequestListViewModel)value;
        }

        public DonorRequestListViewModel ViewModel
        {
            get => (DonorRequestListViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }
    }
}
