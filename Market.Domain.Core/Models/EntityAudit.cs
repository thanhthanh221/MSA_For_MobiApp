using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Core.Models
{
    public abstract class EntityAudit : Entity
    {
        protected EntityAudit(DateTime createAt,
                              Guid createBy,
                              DateTime updateAt,
                              Guid updateBy)
        {
            CreateAt = createAt;
            CreateBy = createBy;
            UpdateAt = updateAt;
            UpdateBy = updateBy;
        }
        protected EntityAudit(DateTime createAt,
                              Guid createBy)
        {
            this.CreateAt = createAt;
            this.CreateBy = createBy;
        }

        public DateTime CreateAt { get; set; }
        public Guid CreateBy { get; set; }  
        public DateTime UpdateAt { get; set; }
        public Guid UpdateBy { get; set; }

    }
}
