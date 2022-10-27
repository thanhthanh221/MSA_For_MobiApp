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
        public String name { get; private set; }
        public String alias { get; private set; }
        public String description { get; private set; }
        public String image { get; private set; }

    }
}
