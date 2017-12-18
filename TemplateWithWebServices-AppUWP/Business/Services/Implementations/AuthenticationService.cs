using System;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using UwpClientApp.Data.Api;
using UwpClientApp.Data.Api.APIs;
using UwpClientApp.Presentation.Models.Auth;

namespace UwpClientApp.Business.Services.Implementations
{
    internal class AuthenticationService : IAuthenticationService
    {
        private readonly IPreferencesService _preferencesService;
        private readonly IAuthRestApi _authApi;
        private readonly ContentDialog _contentDialog;

        public AuthenticationService(IPreferencesService preferencesService, IAuthRestApi authApi)
        {
            _preferencesService = preferencesService;
            _authApi = authApi;
            _contentDialog = new ContentDialog();
        }

        public async Task<bool> LoginAsync(string username, string password, bool rememberMe)
        {
            string errorMessage;
            try
            {
                GetTokenModel model = new GetTokenModel()
                {
                    Username = username,
                    Password = password,
                    RememberMe = rememberMe
                };

                await RetrieveTokenAsync(model);
                await UpdateUserInfoAsync();
                LastUpdateIpTime = DateTime.Now;
                return true;
            }
            catch (ApiException ex)
            {
                errorMessage = "Unauthorized";
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            await ShowErrorAsync(errorMessage);
            return false;
        }

        public async Task<UserInfoModel> UpdateUserInfoAsync()
        {
            var userInfoResponse = await _authApi.GetCurrentUserAsync();
            if (userInfoResponse.IsValid)
            {
                _preferencesService.UserInfo = userInfoResponse.Content;
                return userInfoResponse.Content;
            }

            return null;
        }

        public void Logout()
        {
            _preferencesService.Clear();
        }

        private async Task<TokenModel> RetrieveTokenAsync(GetTokenModel model)
        {
            var tokenInfo = await _authApi.RetrieveTokenAsync(model);
            _preferencesService.TokenInfo = tokenInfo;
            return tokenInfo;
        }

        private DateTime LastUpdateIpTime
        {
            get => _preferencesService.LastUpdateTokenTime;
            set => _preferencesService.LastUpdateTokenTime = value;
        }

        private async Task ShowErrorAsync(string message)
        {
            _contentDialog.Title = "Error";
            var textBlock = new TextBlock {Text = message};
            _contentDialog.Content = textBlock;

            _contentDialog.CloseButtonText = "OK";
            await _contentDialog.ShowAsync();
        }
    }
}