using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Application.Dtos;
using Market.Domain.Model;

namespace Market.Application.Mapper
{
    public static class ProductMapper 
    {
        public static Product MapperToProductByCreate(this ProductCreateDto productCreateDto)
        {
            Product product = new Product(
                Guid.NewGuid(),
                productCreateDto.Name,
                productCreateDto.Price,
                null,
                productCreateDto.Calo,
                productCreateDto.Descretion,
                productCreateDto.Alias,
                productCreateDto.Warranty,
                productCreateDto.PromotionPrice,
                productCreateDto.Quantity,
                productCreateDto.OriginalPrice,
                DateTime.Now,
                productCreateDto.CreateBy
            );
            return product;

        }
        
    }
}
