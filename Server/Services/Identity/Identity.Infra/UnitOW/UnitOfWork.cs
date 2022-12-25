using Identity.Domain.Interfaces;
using Identity.Infra.ServiceContext;

namespace Identity.Infra.UnitOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IdentityServiceContext context;

        public UnitOfWork(IdentityServiceContext context)
        {
            this.context = context;
        }

        public async Task<bool> SaveDbAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}