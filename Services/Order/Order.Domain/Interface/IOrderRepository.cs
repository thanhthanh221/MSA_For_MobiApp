using Order.Domain.Model;

namespace Order.Domain.Interface
{
    // Repository For Aggregate Root Order
    public interface IOrderRepository : IRepositoryAsync<OrderAggregate>
    {
        Task<IList<OrderAggregate>> GetByUserIdAsync(Guid userId);
         
    }
}