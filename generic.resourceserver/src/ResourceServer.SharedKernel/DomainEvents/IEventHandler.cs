namespace ResourceServer.SharedKernel.DomainEvents
{
    /// <summary>
    /// Handler interface for domain events. All domain event handler should implement this interface.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEventHandler<in T> where T: IDomainEvent
    {
        void Handle(T domainEvent);
    }
}