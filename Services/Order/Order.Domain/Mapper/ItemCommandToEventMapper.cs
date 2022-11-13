using AutoMapper;
using Order.Domain.Commands.OrderCommand;
using Order.Domain.Events.OrderEvent;

namespace Order.Domain.Mapper
{
    public class ItemCommandToEventMapper : Profile
    {
        public ItemCommandToEventMapper()
        {
            CreateMap<OrderItemWriteCommand, ProductPulish>()
                .ConstructUsing(orderIt =>
                    new ProductPulish(orderIt.productId, orderIt.count)
                );
        }
    }
}
