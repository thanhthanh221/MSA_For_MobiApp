using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Dtos
{
    public class CategoryReadDto
    {
        public CategoryReadDto(Guid id,
                               string name,
                               string alias,
                               string descretion,
                               string image,
                               Guid createBy,
                               DateTimeOffset createAt,
                               Guid updateBy,
                               DateTimeOffset updateAt)
        {
            Id = id;
            this.name = name;
            this.alias = alias;
            this.descretion = descretion;
            this.image = image;
            this.createBy = createBy;
            this.createAt = createAt;
            this.updateBy = updateBy;
            this.updateAt = updateAt;
        }

        public Guid Id { get; set; }
        public String name { get; set; }
        public String alias { get; set; }
        public String descretion { get; set; }
        public String image { get; set; }

        // Base Entity
        public Guid createBy { get; set; }
        public DateTimeOffset createAt { get; set; }
        public Guid updateBy { get; set; }
        public DateTimeOffset updateAt { get; set; }

    }
}
