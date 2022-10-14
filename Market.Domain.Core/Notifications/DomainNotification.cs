using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Domain.Core.Events;

namespace Market.Domain.Core.Notifications
{
    public class DomainNotification : Event
    {
        public DomainNotification(string Key, string Value)
        {
            DomainNofiticationId = Guid.NewGuid();
            this.Key = Key;
            this.Value = Value;
            Version = 1;
        }

        public Guid DomainNofiticationId { get;private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }
        public int Version { get; private set; }

    }
}
