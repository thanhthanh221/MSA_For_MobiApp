using Application.Common.Events;

namespace EventBus.Messages.Events
{
    public class UserSaveCouponEvent : IntegrationBaseEvent
    {
        public Guid UserId { get; set; }
        public Guid CouponId { get; set; }
        
    }
}
