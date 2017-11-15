using System;
using Windows.UI.Xaml;
using Autofac;
using ReactiveUI;
using UwpClientApp.Presentation.ViewModels.PatientRequest;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace UwpClientApp.Presentation.Views.MenuPage.Patient
{
    public sealed partial class PatientRequestDetailsPage : IViewFor<PatientRequestDetailsViewModel>
    {
        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(PatientRequestDetailsViewModel), typeof(PatientRequestDetailsPage), new PropertyMetadata(default(PatientRequestDetailsViewModel)));

        public PatientRequestDetailsPage()
        {
            InitializeComponent();
            ViewModel = App.Container.Resolve<PatientRequestDetailsViewModel>();

            this.WhenActivated(CreateBindings);
        }

        private void CreateBindings(Action<IDisposable> d)
        {

        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (PatientRequestDetailsViewModel)value;
        }

        public PatientRequestDetailsViewModel ViewModel
        {
            get => (PatientRequestDetailsViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }
    }
}
