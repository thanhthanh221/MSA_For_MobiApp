using Order.Domain.Model;

namespace Order.Domain.Interface
{
    // Repository For Aggregate Root Order
    public interface IOrderRepositoryAsync : IRepositoryAsync<OrderAggregate>
    {
        Task<IEnumerable<OrderAggregate>> GetByUserIdAsync(Guid userId);
         
    }
}