using Market.Domain.Core.Models;

namespace Market.Domain.Interface
{
    public interface IAsyncRepository<TEntity> where TEntity : EntityAudit
    {
        Task<TEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity> spec);
        Task UpdateAsync(TEntity obj);
        Task RemoveAsync(Guid id);
        Task CreateAsync(TEntity obj);
    }
}
