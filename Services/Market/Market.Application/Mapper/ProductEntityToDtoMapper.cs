using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Market.Application.Dtos;
using Market.Domain.Model;

namespace Market.Application.Mapper
{
    public class ProductEntityToDtoMapper : Profile
    {
        public ProductEntityToDtoMapper()
        {
            CreateMap<Product, ProductReadDto>()
                .ConstructUsing(p =>
                    new ProductReadDto(
                        p.Id,
                        p.Name,
                        p.Price,
                        p.Calo,
                        p.Descretion,
                        p.Alias,
                        p.Warranty,
                        p.PromotionPrice,
                        p.Quantity,
                        p.OriginalPrice,
                        p.CreateBy,
                        p.CreateAt
                    ));
        }
    }
}
