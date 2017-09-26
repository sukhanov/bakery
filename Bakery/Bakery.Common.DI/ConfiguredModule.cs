using Autofac;
using Microsoft.Extensions.Configuration;

namespace Bakery.Common.DI
{
    public abstract class ConfiguredModule : Module, IConfiguredModule
    {
        public IConfigurationRoot Configuration { get; set; }
    }
}