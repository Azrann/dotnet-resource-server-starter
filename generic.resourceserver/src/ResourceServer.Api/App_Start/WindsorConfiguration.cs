using System;
using System.Reflection;
using System.Web.Http;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ResourceServer.BoundedContext.Data;
using ResourceServer.BoundedContext.Entities;
using ResourceServer.SharedKernel.Repositories;
using log4net;

namespace ResourceServer.Api.App_Start
{
    public static class WindsorConfigurationTest
    {
        public static IWindsorContainer Configure(IWindsorContainer container)
        {
            container.Register(
                AllTypes.Of<ApiController>()
                .FromAssemblyNamed("ResourceServer.Api")
                .LifestyleTransient());

            container.Register(
                AllTypes.FromAssemblyNamed("ResourceServer.BoundedContext")
                .Where(t => Attribute.IsDefined(t, typeof(CastleComponentAttribute))).WithService.DefaultInterfaces().LifestyleTransient());

            container.Register(
                AllTypes.FromAssemblyNamed("ResourceServer.Api")
                .Where(t => Attribute.IsDefined(t, typeof(CastleComponentAttribute))).WithService.DefaultInterfaces().LifestyleTransient());

            container.Register(Component.For<ILog>().Instance(LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)).LifestyleSingleton());

            container.Register(Component.For<IRepository<Company>>().Instance(new Repository<Company>(new CompanyContext())).LifestyleTransient());
            
            return container;
        }
    }
}