using AutoMapper;
using Market.Application.Dtos;
using Market.Application.Helper;
using Market.Domain.Commands.ProductCommand;

namespace Market.Application.Mapper
{
    public class ProductDtoToCommandMapper : Profile
    {
        public ProductDtoToCommandMapper()
        {
            CreateMap<ProductWriteDto,ProductCreateCommand>()
                .ConstructUsing(p => new ProductCreateCommand(
                    Guid.NewGuid(),
                    p.Name,
                    p.Price,
                    p.Calo,
                    null,
                    p.Descretion,
                    p.Alias,
                    p.Warranty,
                    p.PromotionPrice,
                    p.Quantity,
                    p.OriginalPrice,
                    DateTimeOffset.Now,
                    p.UserId
                ));
                
            CreateMap<ProductWriteDto, ProductUpdateCommand>()
                .ConstructUsing(p => new ProductUpdateCommand(
                    Guid.Empty,
                    p.Name,
                    p.Price,
                    p.Calo,
                    p.Descretion,
                    p.Alias,
                    UploadFileHelper.IFormFileToBase64ImageOfVideo(p.Image),
                    p.Warranty,
                    p.PromotionPrice,
                    p.Quantity,
                    p.OriginalPrice,
                    DateTimeOffset.Now,
                    p.UserId
                ));
        }
    }
}
