using System;
using Windows.UI.Xaml;
using Autofac;
using ReactiveUI;
using UwpClientApp.Presentation.ViewModels.DonorRequest;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace UwpClientApp.Presentation.Views.MenuPage.Donor
{
    public sealed partial class CreateDonorRequestPage : IViewFor<CreateDonorRequestViewModel>
    {
        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(CreateDonorRequestViewModel), typeof(CreateDonorRequestPage), new PropertyMetadata(default(CreateDonorRequestViewModel)));

        public CreateDonorRequestPage()
        {
            InitializeComponent();
            ViewModel = App.Container.Resolve<CreateDonorRequestViewModel>();

            this.WhenActivated(CreateBindings);
        }

        private void CreateBindings(Action<IDisposable> d)
        {

        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (CreateDonorRequestViewModel)value;
        }

        public CreateDonorRequestViewModel ViewModel
        {
            get => (CreateDonorRequestViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }
    }
}
