using System;
using Windows.UI.Xaml;
using Autofac;
using ReactiveUI;
using UwpClientApp.Presentation.ViewModels.PatientRequest;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace UwpClientApp.Presentation.Views.MenuPage.Patient
{
    public sealed partial class CreatePatientRequestPage : IViewFor<CreatePatientRequestViewModel>
    {
        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(CreatePatientRequestViewModel), typeof(CreatePatientRequestPage), new PropertyMetadata(default(CreatePatientRequestViewModel)));

        public CreatePatientRequestPage()
        {
            InitializeComponent();
            ViewModel = App.Container.Resolve<CreatePatientRequestViewModel>();

            this.WhenActivated(CreateBindings);
        }

        private void CreateBindings(Action<IDisposable> d)
        {

        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (CreatePatientRequestViewModel)value;
        }

        public CreatePatientRequestViewModel ViewModel
        {
            get => (CreatePatientRequestViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }
    }
}
