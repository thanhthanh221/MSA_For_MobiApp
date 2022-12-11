using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Order.Application.Dtos
{
    public class OrderCreateDto
    {
        public Guid userId { get; set; }

        // Create By
        public Guid createBy { get; set; }
        
        public List<CreateOrderItemDto> orderItemCommands { get; set; }
    }


    // Order Item Dto
    public class CreateOrderItemDto
    {
        [Required]
        public Guid productId { get; set; }
        [Range(1,int.MaxValue)]
        public int count { get; set; }  // số lượng sản phẩm

    }
}
