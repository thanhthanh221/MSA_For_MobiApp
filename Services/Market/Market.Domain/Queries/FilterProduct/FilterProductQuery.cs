using Market.Domain.Model;
using MediatR;

namespace Market.Domain.Queries.FilterProduct
{
    public class FilterProductQuery : IRequest<List<Product>>
    {
        public int MinTimeOrder { get; set; }

        public int MinDistance { get; set; }
        public int MaxDistance { get; set; }

        public int MinMinuteOrder { get; set; }

        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }

        public int MinStar { get; set; }

        public Guid? CategoryId { get; set; }
        public Guid UsetId { get; set; }

        public int Page { get; set; }

    }
}