using System.Threading.Tasks;

namespace UwpClientApp.Business.Services
{
    public interface INetworkService
    {
        bool IsInternetConnectionAvailable { get; }
    }
}
