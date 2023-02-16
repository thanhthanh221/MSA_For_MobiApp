using Market.Product.Domain.Model;

namespace Market.Product.Api.Dtos
{
    public class ProductsDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int Calo { get; set; }
        public string Descretion { get; set; }
        public double Star { get; set; }
        public bool CheckFavourite { get; set; }
        public string Image { get; set; }
        public string TypeName { get; set; }
        public List<ProductType> ProductTypeDtos { get; set; }
        public TimeSpan TimeOrder { get; set; }

        public static ProductsDto ConverProductToDto(ProductAggregate product, Guid? userId) {
            return new ProductsDto() {
                ProductId = product.Id,
                ProductName = product.Name,
                Calo = product.Calo,
                Star = product.Star,
                Image = product.FileName,
                TypeName = product.TypeName,
                ProductTypeDtos = product.ProductTypes,
                CheckFavourite = userId is not null && product.UserLikeProduct.Any(u => u.Equals(userId)),
                TimeOrder = product.TimeOrder
            };
        }
    }
}