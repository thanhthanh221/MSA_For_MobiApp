using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Core.Models
{
    public abstract class EntityAudit : Entity
    {
        public DateTime CreateAt { get; set; }
        public Guid CreateBy { get; set; }  
        public DateTime UpdateAt { get; set; }
        public Guid UpdateBy { get; set; }

    }
}
