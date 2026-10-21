namespace ResourceServer.SharedKernel.ServiceDependency
{
    public interface IServiceDependency
    {
        ServiceDependencyResolverResult Verify();
    }
}