using System;
using System.IO;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Bakery.Common.DI;
using Bakery.Database;
using Bakery.Web.DI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using NLog;
using NLog.Web;

namespace Bakery.Web
{
    public class Startup
    {
        private readonly ILogger _logger;
        private IContainer _container;
        private IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            _logger = LogManager.GetCurrentClassLogger();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            var builder = new ContainerBuilder();
            builder.RegisterConfiguredModulesFromAssemblyContaining<WebModule>(Configuration);
            builder.Populate(services);
            _container = builder.Build();

            return new AutofacServiceProvider(_container);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime applicationLifetime)
        {
            applicationLifetime.ApplicationStarted.Register(OnStarted);

            env.ConfigureNLog("nlog.config");
            app.AddNLogWeb();
            app.Use(async (context, next) => {
                await next();
                if (context.Response.StatusCode == 404 &&
                    !Path.HasExtension(context.Request.Path.Value) &&
                    !context.Request.Path.Value.StartsWith("/api/"))
                {
                    context.Request.Path = "/index.html";
                    await next();
                }
            });
            app.UseMvcWithDefaultRoute();
            app.UseDefaultFiles();
            app.UseStaticFiles();
        }

        private void OnStarted()
        {
            _logger.Info("Start");
            MigrateDB();
        }

        private void MigrateDB()
        {
            try
            {
                var context = _container.Resolve<Context>();
                context.Migrate();
            }
            catch (Exception e)
            {
                _logger.Error(e, $"Migrate database error: {e}");
            }
        }
    }
}