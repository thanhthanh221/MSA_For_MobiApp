namespace Common.Events
{
    public interface IEvent
    {
        public Guid Id { get; }
        public Guid AggregateId { get; }
        public DateTime Timestamp { get; }
        public object Data { get; }
    }
}