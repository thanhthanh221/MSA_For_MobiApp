using AutoMapper;
using Order.Application.Dtos;
using Order.Domain.Commands.OrderCommand;
using Order.Domain.Model;

namespace Order.Application.Mapper
{
    public class OrderDtoToCommandMappper : Profile
    {
        public OrderDtoToCommandMappper()
        {
            CreateMap<OrderWriteDto, OrderCreateCommand>()
               .ConstructUsing(or =>
                    new OrderCreateCommand(
                        or.userId,
                        or.description,
                        or.isDraft,
                        OrderStatus.Submitted,
                        or.address,
                        or.orderItemWriteDtos,
                        or.userId
                    )
               );
        }
    }
}
