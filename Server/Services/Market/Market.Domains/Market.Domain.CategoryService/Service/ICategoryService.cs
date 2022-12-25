using Market.Domain.CategoryService.Model;

namespace Market.Domain.CategoryService.Service
{
    public interface ICategoryService
    {
        Task<CategoryAggregate> GetByIdAsync(Guid CategoryId);
        Task<List<CategoryAggregate>> GetAllAsync();
        Task CreateAsync();
        Task UpdateAsync();
        Task DeleteAsync(Guid Id);
        
    }
}
