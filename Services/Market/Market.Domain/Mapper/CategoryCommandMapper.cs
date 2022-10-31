using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Market.Domain.Commands.CategoryCommand;
using Market.Domain.Model;

namespace Market.Domain.Mapper
{
    public class CategoryCommandMapper : Profile
    {
        public CategoryCommandMapper()
        {
            CreateMap<CategoryCreateCommand, Category>()
                .ConvertUsing(c =>
                    new Category(
                        c.Id,
                        c.name,
                        c.alias,
                        c.description,
                        c.image,
                        c.CreateAt,
                        c.CreateBy
                    ));
            CreateMap<CategoryUpdateCommand, Category>()
                .ConstructUsing(c =>
                    new Category(
                        c.Id,
                        c.name,
                        c.alias,
                        c.description,
                        c.image,
                        c.CreateAt,
                        c.CreateBy,
                        c.UpdateAt,
                        c.UpdateBy
                    ));
        }
    }
}
