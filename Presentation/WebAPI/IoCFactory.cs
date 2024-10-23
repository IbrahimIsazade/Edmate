using Autofac.Extensions.DependencyInjection;
using Autofac;
using Persistence;
using Autofac.Core;
using Services.Registration;

namespace WebAPI
{
    public class IoCFactory : AutofacServiceProviderFactory
    {
        public IoCFactory() : base(Register) { }

        private static void Register(ContainerBuilder builder)
        {
            builder.RegisterModule<PersistenceRegisterModule>();

            builder.RegisterModule<ServiceRegisterModule>();
        }
    }
}
