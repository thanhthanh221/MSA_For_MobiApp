using AutoMapper;
using Market.Application.Dtos;
using Market.Domain.Commands.CategoryCommand;

namespace Market.Application.Mapper
{
    public class CategoryDtoToCommandMapper : Profile
    {
        public CategoryDtoToCommandMapper()
        {
            // Write Dto => CreateCommand
            CreateMap<CategoryWriteDto, CategoryCreateCommand>()
                .ConstructUsing(c => 
                    new CategoryCreateCommand(
                        Guid.NewGuid(),
                        c.name,
                        c.alias,
                        c.descretion,
                        null,
                        DateTimeOffset.Now,
                        c.userId
                    ));

            //Write Dto => UpdateCommand
            CreateMap<CategoryWriteDto,CategoryUpdateCommand>()
                .ConstructUsing(c => 
                    new CategoryUpdateCommand(
                        Guid.NewGuid(),
                        c.name,
                        c.alias,
                        c.descretion,
                        null,
                        DateTimeOffset.Now,
                        c.userId
                    ));

        }
    }
}