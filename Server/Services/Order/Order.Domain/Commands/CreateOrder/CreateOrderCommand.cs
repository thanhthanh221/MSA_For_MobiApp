using MediatR;
using Order.Domain.Core.Commands;
using Order.Domain.Model;

namespace Order.Domain.Commands.CreateOrder
{
    public class CreateOrderCommand : Command
    {
        public CreateOrderCommand()
        {
        }

        public CreateOrderCommand(Guid userId,
                                  String userName,
                                  string city, 
                                  string district, 
                                  string commune, 
                                  string street, 
                                  string detail,
                                  List<CreateOrderItemCommand> orderItemCommands)
        {
            this.userId = userId;
            this.city = city;
            this.district = district;
            this.commune = commune;
            this.street = street;
            this.detail = detail;
            this.orderItemCommands = orderItemCommands;
        }
        // user

        public Guid userId { get; private set; }
        public String userName { get; private set; }

        // Address
        public String city { get; private set; }        // thành phố/tỉnh
        public String district { get; private set; }    // huyện/quận
        public String commune {get; private set;}     // xã/phường
        public String street { get; private set; }    // đường
        public String detail {get; private set;}       // Mô tả vị trí

        // List Item
        public List<CreateOrderItemCommand> orderItemCommands { get; private set; }


        public override bool IsValid()
        {
            ValidationResult = new CreateOrderCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }


    // Order Item Command
    public class CreateOrderItemCommand
    {
        public CreateOrderItemCommand(Guid productId,
                                      string productName,
                                      decimal price,
                                      int count,
                                      string image)
        {
            this.productId = productId;
            this.productName = productName;
            this.price = price;
            this.count = count;
            this.image = image;
        }

        public Guid productId { get; private set; }
        public String productName { get; private set; }
        public decimal price { get; private set; }
        public string image { get; private set; }
        public int count { get; private set; }
    }
}