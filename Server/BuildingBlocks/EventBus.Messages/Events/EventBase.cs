using MediatR;

namespace EventBus.Messages.Events
{
    public abstract class EventBase : INotification
    {
        public EventBase()
        {
            Id = Guid.NewGuid();
        }
        private Guid Id {get; set;}
        private DateTime dateTime {get; set;}
    }
}
