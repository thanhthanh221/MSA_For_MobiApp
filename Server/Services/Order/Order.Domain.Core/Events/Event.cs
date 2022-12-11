using MediatR;

namespace Order.Domain.Core.Events
{
    public abstract class Event : INotification
    {
        // thời gian thực hiện
        public DateTime dateTime { get; private set; }
        //Message
        public bool eventType {get; set;}
        protected Event(bool eventType)
        {
            this.dateTime = DateTime.UtcNow;
            this.eventType = eventType;
        }
    }
}
