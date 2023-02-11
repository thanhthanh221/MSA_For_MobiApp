using Market.Product.Domain.Model;
using MediatR;

namespace Market.Product.Domain.Queries.SearchProduct
{
    public class SearchProductQuery : IRequest<List<ProductAggregate>>
    {

        public int MinDistance { get; set; }
        public int MaxDistance { get; set; }

        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }

        public int MinTimeOrder { get; set; }

        public int MinStar { get; set; }

        public Guid? CategoryId { get; set; }
        public Guid? UsetId { get; set; }
    }
}