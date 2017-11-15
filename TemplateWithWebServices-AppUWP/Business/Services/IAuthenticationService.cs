using System.Threading.Tasks;
using UwpClientApp.Presentation.Models.Auth;

namespace UwpClientApp.Business.Services
{
    public interface IAuthenticationService
    {
        Task<bool> LoginAsync(string username, string password, bool rememberMe);

        Task<UserInfoModel> UpdateUserInfoAsync();
        
        void Logout();
    }
}
