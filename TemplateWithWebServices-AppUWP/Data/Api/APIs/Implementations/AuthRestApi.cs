using System;
using System.Threading.Tasks;
using UwpClientApp.Data.Api.Rest;
using UwpClientApp.Presentation.Models;
using UwpClientApp.Presentation.Models.Auth;

namespace UwpClientApp.Data.Api.APIs.Implementations
{
    public class AuthRestApi : RestApiBase, IAuthRestApi
    {
        private const string BaseApiAddress = ApiRouting.BaseApiUrl;
        
        public AuthRestApi() : base(new Uri(BaseApiAddress)) { }

        public Task<TokenModel> RetrieveTokenAsync(GetTokenModel model)
        {
            return Url("token")
                .FormUrlEncoded()
                .Param(nameof(model.Username), model.Username)
                .Param(nameof(model.Password), model.Password)
                .Param(nameof(model.RememberMe), model.RememberMe.ToString())
                .PostAsync<TokenModel>();
        }

        public Task<ResponseWrapper<UserInfoModel>> GetCurrentUserAsync()
        {
            return Url("account/GetUserInfo")
                .GetAsync<ResponseWrapper<UserInfoModel>>();
        }
    }
}
