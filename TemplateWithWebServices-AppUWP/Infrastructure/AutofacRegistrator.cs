using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using UwpClientApp.Presentation.ViewModels;

namespace UwpClientApp.Infrastructure
{
    public static class AutofacRegistrator
    {
        public static void RegisterTypes(ContainerBuilder builder)
        {
            //builder.RegisterType<>()
            RegisterViewModels(builder);
        }

        private static void RegisterViewModels(ContainerBuilder builder)
        {
            builder.RegisterType<MenuContentViewModel>().AsSelf().AsImplementedInterfaces();
        }
    }
}
