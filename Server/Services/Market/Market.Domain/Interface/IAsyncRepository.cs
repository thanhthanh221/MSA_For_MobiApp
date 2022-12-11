using Market.Domain.Models;

namespace Market.Domain.Interface
{
    public interface IAsyncRepository<TEntity> where TEntity : IAggregate
    {
        Task<TEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task UpdateAsync(TEntity obj);
        Task RemoveAsync(Guid id);
        Task CreateAsync(TEntity obj);
    }
}
