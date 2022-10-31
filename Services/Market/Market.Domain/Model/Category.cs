using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Domain.Core.Models;

namespace Market.Domain.Model
{
    public class Category : EntityAudit
    {
        public Category(DateTimeOffset createAt,
                        Guid createBy,
                        DateTimeOffset updateAt,
                        Guid updateBy) : base(createAt, createBy, updateAt, updateBy)
        {
        }

        // Full Atrubute For Update
        public Category(Guid Id,
                        string name,
                        string alias,
                        string description,
                        string image,
                        DateTimeOffset createAt,
                        Guid createBy,
                        DateTimeOffset updateAt,
                        Guid updateBy)  : base(createAt, createBy, updateAt, updateBy)
        {
            this.Id = Id;
            this.name = name;
            this.alias = alias;
            this.description = description;
            this.image = image;
        }

        // Create Category From Command
        public Category(Guid Id,
                        string name,
                        string alias,
                        string description,
                        string image,
                        DateTimeOffset createAt,
                        Guid createBy) : base(createAt, createBy)
        {
            this.Id = Id;
            this.name = name;
            this.alias = alias;
            this.description = description;
            this.image = image;
        }

        public String name { get; private set; }
        public String alias { get; private set; }
        public String description { get; private set; }
        public String image { get; private set; }

    }
}
