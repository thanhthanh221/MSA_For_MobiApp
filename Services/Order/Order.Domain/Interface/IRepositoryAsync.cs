using Order.Domain.Core.Models;

namespace Order.Domain.Interface
{
    public interface IRepositoryAsync<T> where T : IAggregateRoot
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
