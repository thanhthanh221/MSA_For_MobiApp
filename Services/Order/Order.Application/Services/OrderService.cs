using Order.Application.Dtos;
using Order.Application.Interfaces;

namespace Order.Application.Services
{
    public class OrderService : IOrderService
    {
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
        public Task CreateAsync(OrderWriteDto writeDto)
        {
            throw new NotImplementedException();
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
