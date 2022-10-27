
using AutoMapper;
using Market.Application.Dtos;
using Market.Domain.Model;

namespace Market.Application.Mapper
{
    public class CategoryEntityToDtoMapper : Profile
    {
        public CategoryEntityToDtoMapper()
        {
            CreateMap<Category,CategoryReadDto>()
                .ConstructUsing(c => 
                    new CategoryReadDto(
                        c.Id,
                        c.name,
                        c.alias,
                        c.description,
                        null,
                        c.CreateBy,
                        c.CreateAt,
                        c.UpdateBy,
                        c.UpdateAt
                    ));
        }
    }
}