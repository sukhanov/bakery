using Autofac;
using Bakery.Services.Implementations;
using Bakery.Services.Interfaces;

namespace Bakery.Services.DI
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Service>().As<IService>();
        }
    }
}