using Autofac;
using Bakery.Common.DI;
using Microsoft.Extensions.Configuration;

namespace Bakery.Database.DI
{
    public class DatabaseModule : ConfiguredModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(n=>new Context(Configuration.GetConnectionString("Default"))).AsSelf();
        }
    }
}