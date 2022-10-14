using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Application.Dtos;
using Market.Domain.Model;

namespace Market.Application.Interfaces
{
    public interface IProductServices : IDisposable
    {
        Task RegisterAsync(ProductReadDto productDto);
        Task<IEnumerable<ProductReadDto>> GetAllAsync();
        Task<Product> GetById(Guid Id);
        Task DeleteAsync(Guid Id);
        Task UpdateAsync(ProductReadDto productDto, Guid Id);


    }
}
