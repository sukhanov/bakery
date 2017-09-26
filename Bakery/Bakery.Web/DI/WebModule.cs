using Autofac;
using Bakery.Common.DI;
using Bakery.Database.DI;

namespace Bakery.Web.DI
{
    public class WebModule : ConfiguredModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterConfiguredModulesFromAssemblyContaining<DatabaseModule>(Configuration);
        }
    }
}