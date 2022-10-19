using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Core.Models
{
    public abstract class EntityAudit : Entity
    {
        protected EntityAudit(DateTimeOffset createAt,
                              Guid createBy,
                              DateTimeOffset updateAt,
                              Guid updateBy)
        {
            CreateAt = createAt;
            CreateBy = createBy;
            UpdateAt = updateAt;
            UpdateBy = updateBy;
        }
        protected EntityAudit(DateTimeOffset createAt,
                              Guid createBy)
        {
            this.CreateAt = createAt;
            this.CreateBy = createBy;
        }

        public DateTimeOffset CreateAt { get; set; }
        public Guid CreateBy { get; set; }  
        public DateTimeOffset UpdateAt { get; set; }
        public Guid UpdateBy { get; set; }

    }
}
