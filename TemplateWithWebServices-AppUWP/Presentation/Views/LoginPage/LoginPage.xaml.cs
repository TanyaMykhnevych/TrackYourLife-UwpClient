using System;
using Windows.UI.Xaml;
using Autofac;
using ReactiveUI;
using UwpClientApp.Presentation.ViewModels;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace UwpClientApp.Presentation.Views.LoginPage
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class LoginPage : IViewFor<LoginViewModel>
    {
        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(LoginViewModel), typeof(LoginPage), new PropertyMetadata(default(LoginViewModel)));

        public LoginPage()
        {
            InitializeComponent();
            ViewModel = App.Container.Resolve<LoginViewModel>();

            this.WhenActivated(CreateBindings);
        }

        private void CreateBindings(Action<IDisposable> d)
        {
            d(this.OneWayBind(ViewModel, vm => vm.IsBusy, v => v.Preloader.IsLoading));

            d(this.Bind(ViewModel, vm => vm.LoginModel.Username, v => v.EmailTextBox.Text));
            d(this.Bind(ViewModel, vm => vm.LoginModel.Password, v => v.PasswordBox.Password));
            d(this.Bind(ViewModel, vm => vm.LoginModel.RememberMe, v => v.RememberMeCheckBox.IsChecked));

            d(this.BindCommand(ViewModel, vm => vm.SignInCommand, v => v.SignInButton));
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (LoginViewModel)value;
        }

        public LoginViewModel ViewModel
        {
            get => (LoginViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }
    }
}
