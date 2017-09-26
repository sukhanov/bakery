using Autofac;
using Bakery.Repositories.Implementations;
using Bakery.Repositories.Interfaces;

namespace Bakery.Repositories.DI
{
    public class RepositoriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Repository>().As<IRepository>();
        }
    }
}