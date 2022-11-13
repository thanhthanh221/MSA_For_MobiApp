using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Core.Events
{
    public class Event
    {
        // thời gian thực hiện
        public DateTime dateTime { get; private set; }
        //Message
        public bool eventType { get; set; }
        protected Event(bool eventType)
        {
            this.dateTime = DateTime.UtcNow;
            this.eventType = eventType;
        }
    }
}
