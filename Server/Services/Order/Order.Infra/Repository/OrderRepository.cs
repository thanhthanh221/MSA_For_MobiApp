using Microsoft.EntityFrameworkCore;
using Order.Domain.Interface;
using Order.Domain.Model;
using Order.Infra.ServiceContext;

namespace Order.Infra.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderServiceContext context;

        public OrderRepository(OrderServiceContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(OrderAggregate entity)
        {
            await context.orders.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var order = await GetByIdAsync(id);
            if (order is null) {
                return;
            }
            context.orders.Remove(order);
        }

        public async Task<IList<OrderAggregate>> GetAllAsync()
        {
            List<OrderAggregate> orders = await (from o in context.orders
                                            select o).ToListAsync();
            
            return orders;
        }

        public async Task<OrderAggregate> GetByIdAsync(Guid id)
        {
            OrderAggregate order = await context.orders
                                        .Where(or => or.Id.Equals(id))
                                        .SingleOrDefaultAsync();
            return order;
        }

        public async Task<IList<OrderAggregate>> GetByUserIdAsync(Guid userId)
        {
            List<OrderAggregate> order = await context.orders
                                        .Where(or => or.Id.Equals(userId))
                                        .ToListAsync();
            return order;
        }
        public async Task UpdateAsync(OrderAggregate entity)
        {
            OrderAggregate order = await GetByIdAsync(entity.Id);
            if (order is null) {
                return;
            }
            context.orders.Remove(order);
            await context.orders.AddAsync(entity);
        }
    }
}
