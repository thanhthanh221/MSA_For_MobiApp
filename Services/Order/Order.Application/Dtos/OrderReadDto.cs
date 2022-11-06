using Order.Domain.Model;

namespace Order.Application.Dtos
{
    public class OrderReadDto
    {
        public String userName {get; init;}
        public String description { get; init; }
        public Boolean isDraft { get; init; }
        public String orderStatusName { get; init; }
        public Address address {get; init;}

        // Infomation Entity
        public Guid CreateBy {get; protected set;}
        public DateTime CreateAt {get; protected set;}
        public Guid UpdateBy {get; protected set;}
        public DateTime UpdateAt {get; protected set;}

        public List<OrderItemReadDto> orderItems { get; set; }
    }

    // Order Item Read Dto

    public class OrderItemReadDto
    {
        public string productName { get; init; }
        public decimal price { get; init; }
        public int count { get; set; }
        public string image { get; init; }

    }
}
