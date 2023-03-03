using CheckCategoryExistence.Models;

namespace CheckCategoryExistence.Interfaces
{
    public interface IResponseCheckCategoryExistence
    {
        Task<ResponseCheckCategoryExistence> Handle(ResponseCheckCategoryExistence request);
    }
}