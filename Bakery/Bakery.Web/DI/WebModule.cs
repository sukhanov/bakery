using Autofac;
using Bakery.Common.DI;
using Bakery.Database.DI;
using Bakery.Repositories.DI;
using Bakery.Services.DI;

namespace Bakery.Web.DI
{
    public class WebModule : ConfiguredModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterConfiguredModulesFromAssemblyContaining<DatabaseModule>(Configuration);
            builder.RegisterModule<RepositoriesModule>();
            builder.RegisterModule<ServicesModule>();
        }
    }
}