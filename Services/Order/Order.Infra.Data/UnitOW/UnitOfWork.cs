using Order.Domain.Interface;
using Order.Infra.Data.Data;

namespace Order.Infra.Data.UnitOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrderServiceContext context;

        public UnitOfWork(OrderServiceContext context)
        {
            this.context = context;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();   
        }
    }
}
