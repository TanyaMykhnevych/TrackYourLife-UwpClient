using System.Threading.Tasks;
using UwpClientApp.Presentation.Models;
using UwpClientApp.Presentation.Models.Auth;

namespace UwpClientApp.Data.Api.APIs
{
    public interface IAuthRestApi
    {
        Task<TokenModel> RetrieveTokenAsync(string username, string password, bool rememberme);

        Task<ResponseWrapper<UserInfoModel>> GetCurrentUserAsync();
    }
}
