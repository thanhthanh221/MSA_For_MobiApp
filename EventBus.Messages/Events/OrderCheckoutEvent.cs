namespace EventBus.Messages.Events
{
    public class OrderCheckoutEvent : EventBase
    {
        public Guid userId { get; set; }
        public String userName { get; set; }
        public decimal price { get; set; }

        // Address => Add In Services Identity
        public String city { get; set; }    // thành phố/tỉnh
        public String district { get; set; }     // huyện/quận
        public String commune { get; set; }    // xã/phường
        public String street { get; set; }   // đường
        public String infomation { get; set; } // Mô tả vị trí

        public List<OrderItemCheckoutEvent> products { get; set; }

        // Check Saga

        public Boolean checkOrchestration { get; set; }
        public int CountCheckSaga { get; set; }
        public String MessageError { get; set; }
    }

    public class OrderItemCheckoutEvent
    {
        public Guid productId { get; set; }
        
        // Add In Services Market
        public string productName { get; set; }
        public string image { get; set; }
        public decimal price { get; set; }
        public int count { get; set; }

    }

}
