using CheckCategoryExistence.Models;

namespace CheckCategoryExistence.Interfaces
{
    public interface IRequestCheckCategoryExistence
    {
        Task<RequestCheckCategoryExistence> SendRequestCheckCategoryExistence(Guid CategoryId);
    }
}