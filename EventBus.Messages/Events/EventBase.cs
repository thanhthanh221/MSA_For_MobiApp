namespace EventBus.Messages.Events
{
    public abstract class EventBase
    {
        public EventBase()
        {
            this.Id = Guid.NewGuid();
            this.dateTime = DateTime.UtcNow;
        }

        public EventBase(Guid id, DateTime dateTime)
        {
            Id = id;
            this.dateTime = dateTime;
        }

        private Guid Id {get; set;}
        private DateTime dateTime {get; set;}
    }
}
