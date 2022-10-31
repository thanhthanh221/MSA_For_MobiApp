using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Interface
{
    public interface IRepositoryAsync<T> where T : class
    {
        Task<T> CreateAsync(T entity);

        Task<T> UpdateAsync(T entity);
        Task GetAllAsync();
        Task GetById(Guid id);
        Task DeleteAsync(T entity);
    }
}
