using Application.Common.Model;

namespace Application.Common.Repository
{
    public interface IRepository<TEntity> where TEntity : IAggregateRoot
    {
        Task<TEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task UpdateAsync(TEntity obj);
        Task RemoveAsync(Guid id);
        Task CreateAsync(TEntity obj);

    }
}