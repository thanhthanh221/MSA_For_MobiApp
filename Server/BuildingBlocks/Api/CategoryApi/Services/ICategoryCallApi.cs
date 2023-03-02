using CategoryApi.Models;

namespace CategoryApi.Services
{
    public interface ICategoryCallApi
    {
        Task<CategoryClientRes> GetCategoryByIdCallApi(Guid CategoryId);
        Task<List<CategoryClientRes>> GetAllCategoryCallApi();
    }
}