using System;
using UwpClientApp.Presentation.Models.Auth;

namespace UwpClientApp.Business.Services
{
    public interface IPreferencesService
    {
        DateTime LastUpdateTokenTime { get; set; }

        TokenModel TokenInfo { get; set; }

        UserInfoModel UserInfo { get; set; }

        string AccessToken { get; }

        bool IsLoggedIn { get; }

        void Clear();
    }
}