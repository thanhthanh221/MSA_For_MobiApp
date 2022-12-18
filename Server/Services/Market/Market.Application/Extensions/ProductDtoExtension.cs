using Market.Application.Dtos;
using Market.Domain.ProductService.Model;

namespace Market.Application.Extensions
{
    public static class ProductDtoExtension
    {
        public static ProductsDto ConvertToDto(this ProductAggregate product, Guid userId)
        {
            ProductsDto productsDto = new() {
                ProductId = product.Id,
                ProductName = product.Name,
                Calo = product.Calo,
                Price = product.Price,
                CheckFavourite = product.UserLikeProduct.Any(us => us.Equals(userId)),
                Categories = product.Categories.Select(c => c.CategoryId).ToList(),
                Star = product.Star,
                Image = product.Image
            };
            return productsDto;
        }

        public static ProductDto ConvertOneToDto(this ProductAggregate product, Guid userId)
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
                TypeProductDtos = product.ProductTypes
                                .Select(ty => new TypeProductDto(ty.ValueType, ty.PriceType, ty.QuantityType))
                                .ToList(),
                Image = product.Image
            };
            return productDto;

        }
    }
}
