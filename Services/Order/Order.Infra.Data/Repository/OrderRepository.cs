using Order.Domain.Interface;
using Order.Domain.Model;

namespace Order.Infra.Data.Repository
{
    public class OrderRepository : IOrderRepositoryAsync
    {
        public Task<OrderAggregate> CreateAsync(OrderAggregate entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(OrderAggregate entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderAggregate>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OrderAggregate> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderAggregate>> GetByUserIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<OrderAggregate> UpdateAsync(OrderAggregate entity)
        {
            throw new NotImplementedException();
        }
    }
}
