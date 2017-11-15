using System;
using System.Collections.Generic;
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

        public Task<TokenModel> RetrieveTokenAsync(string username, string password, bool rememberMe)
        {
            return Url("token")
                .FormUrlEncoded()
                .Param(nameof(username), username)
                .Param(nameof(password), password)
                .Param(nameof(rememberMe), rememberMe.ToString())
                .PostAsync<TokenModel>();
        }

        public Task<ResponseWrapper<UserInfoModel>> GetCurrentUserAsync()
        {
            return Url("account/GetUserInfo")
                .GetAsync<ResponseWrapper<UserInfoModel>>();
        }
    }
}
