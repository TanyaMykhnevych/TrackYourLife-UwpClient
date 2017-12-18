using System.Threading.Tasks;
using UwpClientApp.Data.Api.APIs.Implementations;
using UwpClientApp.Presentation.Models;
using UwpClientApp.Presentation.Models.Auth;

namespace UwpClientApp.Data.Api.APIs
{
    public interface IAuthRestApi
    {
        Task<TokenModel> RetrieveTokenAsync(GetTokenModel model);

        Task<ResponseWrapper<UserInfoModel>> GetCurrentUserAsync();
    }
}
