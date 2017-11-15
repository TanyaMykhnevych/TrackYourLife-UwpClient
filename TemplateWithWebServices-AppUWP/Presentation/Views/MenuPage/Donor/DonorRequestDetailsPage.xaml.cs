using System;
using Windows.UI.Xaml;
using Autofac;
using ReactiveUI;
using UwpClientApp.Presentation.ViewModels.DonorRequest;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace UwpClientApp.Presentation.Views.MenuPage.Donor
{
    public sealed partial class DonorRequestDetailsPage : IViewFor<DonorRequestDetailsViewModel>
    {
        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(DonorRequestDetailsViewModel), typeof(DonorRequestDetailsPage), new PropertyMetadata(default(DonorRequestDetailsViewModel)));

        public DonorRequestDetailsPage()
        {
            InitializeComponent();
            ViewModel = App.Container.Resolve<DonorRequestDetailsViewModel>();

            this.WhenActivated(CreateBindings);
        }

        private void CreateBindings(Action<IDisposable> d)
        {

        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (DonorRequestDetailsViewModel)value;
        }

        public DonorRequestDetailsViewModel ViewModel
        {
            get => (DonorRequestDetailsViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }
    }
}
