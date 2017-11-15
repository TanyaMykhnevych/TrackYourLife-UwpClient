using Autofac;
using UwpClientApp.Business.Services;
using UwpClientApp.Business.Services.Implementations;
using UwpClientApp.Data.Api.APIs;
using UwpClientApp.Data.Api.APIs.Implementations;
using UwpClientApp.Presentation.ViewModels;

namespace UwpClientApp.Infrastructure
{
    public static class AutofacRegistrator
    {
        public static void RegisterTypes(ContainerBuilder builder)
        {
            RegisterServices(builder);
            RegisterApis(builder);
            RegisterViewModels(builder);
        }

        private static void RegisterViewModels(ContainerBuilder builder)
        {
            builder.RegisterType<MenuContentViewModel>().AsSelf().AsImplementedInterfaces();
            builder.RegisterType<LoginViewModel>().AsSelf().AsImplementedInterfaces();
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<PreferencesService>().As<IPreferencesService>();
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>();
            builder.RegisterType<NetworkService>().As<INetworkService>();
        }

        private static void RegisterApis(ContainerBuilder builder)
        {
            builder.RegisterType<AuthRestApi>().As<IAuthRestApi>();
        }
    }
}
