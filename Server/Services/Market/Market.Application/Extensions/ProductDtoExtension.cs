using Market.Application.Dtos;
using Market.Domain.Model;

namespace Market.Application.Extensions
{
    public static class ProductDtoExtension
    {
        public static ProductsDto ConvertToDto(this Product product, Guid userId)
        {
            ProductsDto productsDto = new() {
                ProductId = product.Id,
                ProductName = product.Name,
                Calo = product.Calo,
                Price = product.Price,
                CheckFavourite = product.UserLikeProduct.Any(us => us.Equals(userId)),
                Categories = product.Categories.Select(c => c.Id).ToList(),
                Star = product.Star,
                Image = product.Image
            };
            return productsDto;
        }

        public static ProductDto ConvertOneToDto(this Product product, Guid userId)
        {

            ProductDto productDto = new() {
                ProductId = product.Id,
                ProductName = product.Name,
                Calo = product.Calo,
                Price = product.Price,
                TimeOrder = product.TimeOrder,
                CheckFavourite = product.UserLikeProduct
                                .Any(us => us.Equals(userId)),
                TypeName = product.TypeName,
                TypeProductDtos = product.TypeProducts
                                .Select(ty => new TypeProductDto(ty.TypeValue, ty.PriceType, ty.QuantityType))
                                .ToList(),
                Image = product.Image
            };
            return productDto;

        }
    }
}
