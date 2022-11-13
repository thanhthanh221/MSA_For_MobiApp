namespace EventBus.Messages.Events
{
    public class OrderCheckoutEvent : EventBase
    {
        public Guid userId { get; set; }
        public decimal price { get; set; }
        public List<OrderItemCheckoutEvent> products { get; set; }
        public Boolean checkOrchestration { get; set; }
        public int CountCheckSaga {get; set;}
        public String MessageError {get; set;} 
    }

}
