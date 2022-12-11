using Market.Domain.Model;
using MediatR;

namespace Market.Domain.Queries.ProductByCategory
{
    public class ProductByCategoryQuery : IRequest<List<Product>>
    {
        public ProductByCategoryQuery(Guid categoryId,
                                      int page,
                                      string pattern)
        {
            CategoryId = categoryId;
            Page = page;
            PageSize = 10;
            Pattern = pattern;
        }

        public Guid CategoryId {get; private set;}
        public int Page {get; private set;}
        public int PageSize {get ; private set;}
        public string Pattern {get; private set;}
        
    }
}