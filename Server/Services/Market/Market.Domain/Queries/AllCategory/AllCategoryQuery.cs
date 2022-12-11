using Market.Domain.Model;
using MediatR;

namespace Market.Domain.Queries.AllCategory
{
    public class AllCategoryQuery : IRequest<List<Category>>
    {
        
    }
}