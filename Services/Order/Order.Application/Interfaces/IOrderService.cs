using Order.Application.Dtos;

namespace Order.Application.Interfaces
{
    public interface IOrderService : IApplicationService<OrderWriteDto, OrderReadDto>
    {
        Task<IEnumerable<OrderReadDto>> GetByUserIdAsync(Guid Id);
    }
}
