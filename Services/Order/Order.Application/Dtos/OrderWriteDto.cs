using Order.Domain.Model;
using System.ComponentModel.DataAnnotations;

namespace Order.Application.Dtos
{
    public class OrderWriteDto
    {
        // User Infomation
        [Required]
        public Guid userId {get; init;}
        public Address address { get; init; }
        [Required]
        [StringLength(30)]
        public String description { get; init; } 
        [Required]
        public Boolean isDraft {get; init;} // Đã lưu hay chưa
        [Required]
        public List<OrderItemWriteDto> orderItemWriteDtos {get; init;}
    }
    public class OrderItemWriteDto
    {
        public Guid productId { get; init; }
        public decimal discount { get; init; }
        public int count { get; set; }
    }
}
