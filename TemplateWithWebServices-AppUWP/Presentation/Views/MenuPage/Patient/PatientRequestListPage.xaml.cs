using System;
using Windows.UI.Xaml;
using Autofac;
using ReactiveUI;
using UwpClientApp.Presentation.ViewModels.PatientRequest;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace UwpClientApp.Presentation.Views.MenuPage.Patient
{
    public sealed partial class PatientRequestListPage : IViewFor<PatientRequestListViewModel>
    {
        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(PatientRequestListViewModel),
                typeof(PatientRequestListPage), new PropertyMetadata(default(PatientRequestListViewModel)));

        public PatientRequestListPage()
        {
            InitializeComponent();
            ViewModel = App.Container.Resolve<PatientRequestListViewModel>();

            this.WhenActivated(CreateBindings);
        }

        private void CreateBindings(Action<IDisposable> d)
        {
            d(this.OneWayBind(ViewModel, vm => vm.IsBusy, v => v.Preloader.IsLoading));

            d(this.OneWayBind(ViewModel, vm => vm.PatientRequestList, v => v.PatientRequestsMasterDetails.ItemsSource));
            d(this.Bind(ViewModel, vm => vm.SelectedItem, v => v.PatientRequestsMasterDetails.SelectedItem));
            d(this.OneWayBind(ViewModel, vm => vm.MapListItemToDetails, v => v.PatientRequestsMasterDetails.MapDetails));
            d(this.Bind(ViewModel, vm => vm.CurrentViewState, v => v.PatientRequestsMasterDetails.ViewState));
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (PatientRequestListViewModel)value;
        }

        public PatientRequestListViewModel ViewModel
        {
            get => (PatientRequestListViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }
    }
}
