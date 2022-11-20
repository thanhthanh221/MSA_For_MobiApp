using Order.Domain.Core.Models;

namespace Order.Domain.Interface
{
    public interface IRepositoryAsync<T> where T : IAggregateRoot
    {
        Task<IList<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
    }
}
