
namespace Market.Domain.Interface
{
    public interface IAsyncRepository<TEntity> : IDisposable where TEntity : class
    {
        Task Add(TEntity obj);
        Task<TEntity> GetByIdAsync(Guid id);
        Task<IQueryable<TEntity>> GetAllAsync();
        Task<IQueryable<TEntity>> GetAllAsync(ISpecification<TEntity> spec);
        Task<IQueryable<TEntity>> GetAllSoftDeletedAsync();
        Task UpdateAsync(TEntity obj);
        Task RemoveAsync(Guid id);
    }
}
