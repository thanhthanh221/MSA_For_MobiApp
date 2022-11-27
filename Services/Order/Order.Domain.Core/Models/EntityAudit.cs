using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Order.Domain.Core.Models
{
    public abstract class EntityAudit
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName ="varchar(255)")]
        public Guid Id {get; protected set;}
        // DomainEvent
        public List<INotification> domainEvent {get; protected set;}

        // Event Method

        public void AddDomainEvent(INotification eventItem)
        {
            domainEvent.Add(eventItem);
        }

        public void RemoveEvent(INotification eventItem)
        {
            domainEvent.Remove(eventItem);
        }

        // Entity Override

        public override bool Equals(object obj)
        {
            if(!(obj is EntityAudit))
            {
                return false;
            }

            if(Object.ReferenceEquals(this, obj))
            {
                // So sánh nếu là đối tượng EntityAudit
                return true;
            }

            if(this.GetType() != obj.GetType())
            {
                return false;
            }

            EntityAudit entity = (EntityAudit)obj;

            return entity.Id == Id;
        }
    }
}
