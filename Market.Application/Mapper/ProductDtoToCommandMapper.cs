using AutoMapper;
using Market.Application.Dtos;
using Market.Application.Helper;
using Market.Domain.Commands;

namespace Market.Application.Mapper
{
    public class ProductDtoToCommandMapper : Profile
    {
        public ProductDtoToCommandMapper()
        {
            CreateMap<ProductWriteDto,CreateNewProductCommand>()
                .ConstructUsing(p => new CreateNewProductCommand(
                    Guid.NewGuid(),
                    p.Name,
                    p.Price,
                    p.Calo,
                    UploadFileHelper.IFormFileToBase64ImageOfVideo(p.Image),
                    p.Descretion,
                    p.Alias,
                    p.Warranty,
                    p.PromotionPrice,
                    p.Quantity,
                    p.OriginalPrice,
                    DateTimeOffset.Now,
                    p.CreateBy
                ));
                
            CreateMap<ProductWriteDto, UpdateProductCommand>()
                .ConstructUsing(p => new UpdateProductCommand(
                    Guid.NewGuid(),
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
                    p.CreateBy
                ));
        }
    }
}
