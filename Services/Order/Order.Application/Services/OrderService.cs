using AutoMapper;
using Order.Application.Dtos;
using Order.Application.Interfaces;
using Order.Domain.Commands.OrderCommand;
using Order.Domain.Core.Bus;
using Order.Domain.Interface;
using Order.Domain.Model;

namespace Order.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMediatorHandler bus;
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;

        public OrderService(IMediatorHandler bus,
                            IOrderRepository orderRepository,
                            IMapper mapper)
        {
            this.bus = bus;
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }

        // Query Service
        public Task<IEnumerable<OrderReadDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OrderReadDto> GetByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderReadDto>> GetByUserIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        // Command Service
        public async Task CreateAsync(OrderWriteDto writeDto)
        {
            // khởi tạo Order lúc ban đầu
            OrderStatus orderStatus = OrderStatus.Submitted;
            

            // Gửi event đi
            // await bus.RaiseEvent();
            
        }

        public Task DeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
        }
        public Task UpdateAsync(OrderWriteDto writeDto, Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
