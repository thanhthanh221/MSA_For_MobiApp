using Order.Domain.Interface;
using Order.Infra.ServiceContext;

namespace Order.Infra.UnitOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrderServiceContext context;

        public UnitOfWork(OrderServiceContext context)
        {
            this.context = context;
        }

        public async Task<bool> SaveDbAsync()
        {
            return await context.SaveChangesAsync() > 0;   
        }
    }
}
