using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Market.Application.Dtos
{
    public class CategoryWriteDto
    {
        public CategoryWriteDto()
        {
        }

        public CategoryWriteDto(Guid id,
                                string name,
                                string alias,
                                string descretion,
                                IFormFile image,
                                Guid userId)
        {
            Id = id;
            this.name = name;
            this.alias = alias;
            this.descretion = descretion;
            this.image = image;
            this.userId = userId;
        }

        public Guid Id { get; set; }
        public String name { get; set; }
        public String alias { get; set; }
        public String descretion { get; set; }
        public IFormFile image { get; set; }
        public Guid userId { get; set; }
    }
}
