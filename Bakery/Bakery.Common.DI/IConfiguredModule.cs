using Microsoft.Extensions.Configuration;

namespace Bakery.Common.DI
{
    public interface IConfiguredModule
    {
        IConfigurationRoot Configuration { get; set; }
    }
}