using AutoMapper;
using Market.Domain.Commands.ProductCommand;
using Market.Domain.Model;

namespace Market.Domain.Mapper
{
    public class ProductCommandMapper : Profile
    {
        public ProductCommandMapper()
        {
            CreateMap<ProductCreateCommand,Product>()
                .ConstructUsing(p =>
                    new Product(
                        p.Id,
                        p.Name,
                        p.Price,
                        p.Image,
                        p.Calo,
                        p.Descretion,
                        p.Alias,
                        p.Warranty,
                        p.PromotionPrice,
                        p.Quantity,
                        p.OriginalPrice,
                        p.CreateAt,
                        p.CreateBy
                        ));
            CreateMap<ProductUpdateCommand,Product>()
                .ConstructUsing(p =>
                    new Product(
                        p.Id,
                        p.Name,
                        p.Price,
                        p.Image,
                        p.Calo,
                        p.Descretion,
                        p.Alias,
                        p.Warranty,
                        p.PromotionPrice,
                        p.Quantity,
                        p.OriginalPrice,
                        p.CreateAt,
                        p.CreateBy,
                        p.UpdateAt,
                        p.UpdateBy
                        ));

        }
    }
}