using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ReactiveUI;
using UwpClientApp.Business.Services;
using UwpClientApp.Presentation.Models.Auth;
using UwpClientApp.Presentation.Views.MenuPage;

namespace UwpClientApp.Presentation.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IAuthenticationService _authenticationService;

        private ReactiveCommand _signInCommand;

        public LoginViewModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;

            SignInCommand = ReactiveCommand.CreateFromTask(SignIn);

            LoginModel = new LoginModel
            {
                Username = "medEmployee1@test.com",
                Password = "Test123!",
                RememberMe = true
            };
        }

        public LoginModel LoginModel { get; }

        public ReactiveCommand SignInCommand
        {
            get => _signInCommand;
            set => this.RaiseAndSetIfChanged(ref _signInCommand, value);
        }

        private async Task SignIn()
        {
            IsBusy = true;
            try
            {
                bool isSuccess = await _authenticationService.LoginAsync(LoginModel.Username, LoginModel.Password, LoginModel.RememberMe);
                if (isSuccess)
                {
                    var frame = Window.Current.Content as Frame;
                    frame?.Navigate(typeof(MenuContentPage));
                }
            }
            catch (Exception ex)
            {
                await ShowErrorAsync(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
