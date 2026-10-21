using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ResourceServer.BoundedContext.Data;
using ResourceServer.BoundedContext.Entities;
using ResourceServer.SharedKernel.Repositories;

namespace ResourceServer.BoundedContext.Infrastructure
{
    public class WindsorBoundedContext
    {
        public static IWindsorContainer Configure(IWindsorContainer container)
        {
            container.Register(Component.For<IRepository<Company>>().Instance(new Repository<Company>(new CompanyContext())));
            
            return container;
        }
    }
}
