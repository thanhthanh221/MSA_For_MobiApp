using Common.Events;

namespace Events.Stores
{
    public interface IEventStore
    {
        Task<IEnumerable<IEvent>> GetEvents(Guid aggregateId);
        Task AppendEvent(IEvent @event);
    }
}