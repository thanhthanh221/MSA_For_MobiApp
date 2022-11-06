using AutoMapper;
using Order.Application.Dtos;
using Order.Domain.Model;

namespace Order.Application.Mapper
{
    public class OrderEntityToDtoMapper : Profile
    {
        public OrderEntityToDtoMapper()
        {
            CreateMap<OrderAggregate, OrderReadDto>()
                .ConstructUsing(or => 
                    new OrderReadDto()
                    {
                        userName = or.userName,
                        description = or.description,
                        isDraft = or.isDraft,
                        orderStatusName = or.orderStatus.name,
                        address = or.address,
                        orderItems = null
                    }
                );
            
            // OrderItem => orderItemReadDto;
            CreateMap<OrderItem, OrderItemReadDto>()
                .ConstructUsing(or => 
                    new OrderItemReadDto()
                    {
                        productName = or.productName,
                        price = or.price,
                        count = or.count,
                        image = or.image
                    });
        }
    }
}