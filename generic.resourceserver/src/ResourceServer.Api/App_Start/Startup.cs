using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Web.Http;
using Bookatable.Neptune.Auth.API;
using Castle.Windsor;
using ResourceServer.BoundedContext.Data;
using ResourceServer.BoundedContext.Entities;
using ResourceServer.SharedKernel.AppStart.Windsor;
using ResourceServer.SharedKernel.Ioc;
using ResourceServer.SharedKernel.Repositories;
using ResourceServer.SharedKernel.ServiceDependency;
using ResourceServer.SharedKernel.ServiceHealth;
using log4net;
using log4net.Config;
using Owin;
using WebApiContrib.IoC.CastleWindsor;

namespace ResourceServer.Api.App_Start
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        private readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        public static ServiceHealthStatusEventStore ServiceHealthStatus { get; set; }
        
        public virtual void Configuration(IAppBuilder app)
        {
            XmlConfigurator.Configure();

            _logger.Info("ResourceServer startup...");

            LogConfigurationSettings();

            WebApiConfigurationBuilder.SetDefaults();
            
            ServiceHealthStatus = new ServiceHealthStatusEventStore();

            _logger.Info("Service dependencies healthcheck...");
            var dependenciesHealthCheckResult = ServiceDependencyCheck();

            if (dependenciesHealthCheckResult.HealthStatus == HealthStatus.Faulty)
            {
                GlobalConfiguration.Configuration.Routes.MapHttpRoute("Root", "version", new { controller = "Version", action = "GetAsync" });
                _logger.Error("ResourceServer could not load all dependencies. Service status is faulty.");
                app.UseWebApi(GlobalConfiguration.Configuration);
                return;
            }

            _logger.Info("All service dependencies are OK!");

            _logger.Info("Setting up Windsor Castle container...");

            WindsorConfigurationTest.Configure(ContainerManager.Container);
        /*    WindsorBoundedContext.Configure(ContainerManager.Container);

            WindsorConfiguration.Configure(ContainerManager.Container);*/

            GlobalConfiguration.Configuration.DependencyResolver = new WindsorResolver(ContainerManager.Container);
            
            app.ConfigureOAuth();

            app.UseWebApi(GlobalConfiguration.Configuration);

            _logger.Info("All done! AuthServer started successfully.");
        }

        private ServiceDependencyResolverResultSummary ServiceDependencyCheck()
        {
            bool isServiceHealthy = true;

            var dependenciesHealthCheckResult = new ServiceDependencyContainer()
                .Register(new List<ServiceDependency>()
                              {
                                  new ServiceDependency("CompanyContext", () => new Repository<Company>(new CompanyContext())),
                                 // new ServiceDependency("IOCComponents", () =>  WindsorConfiguration.Configure(WindsorBoundedContext.Configure(new WindsorContainer())).Verify())
                                 new ServiceDependency("IOCComponents", () =>   WindsorConfigurationTest.Configure(new WindsorContainer()).Verify())
                              })
                .VerifyAll();

            foreach (var result in dependenciesHealthCheckResult)
            {
                if (result.Value.Resolved)
                {
                    _logger.Info(string.Format("Dependency [{0}] resolved.", result.Key));
                }
                else
                {
                    isServiceHealthy = false;
                    var errorMessage = string.Format("Couldn't resove dependency [{0}].ErrorMessage=[{1}].", result.Key, result.Value.Message);
                    _logger.Error(errorMessage);
                    ServiceHealthStatus.SetFaultyStatus(errorMessage);
                }
            }

            if (isServiceHealthy)
            {
                ServiceHealthStatus.SetOkStatus();
            }

            return dependenciesHealthCheckResult;
        }

        private void LogConfigurationSettings()
        {
            foreach (var key in ConfigurationManager.AppSettings.AllKeys)
            {
                _logger.InfoFormat("Configuration setting key=[{0}], value=[{1}].", key, ConfigurationManager.AppSettings[key]);
            }
        }
    }
}