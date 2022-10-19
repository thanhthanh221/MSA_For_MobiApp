using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Core.Models
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; protected set; }

        public override bool Equals(object obj)
        {
            Entity entity = obj as Entity;
            if (entity is null )
            {
                return false;
            }
            return entity.Id.Equals(this.Id);
        }
        public override int GetHashCode()
        {
            return this.GetHashCode();
        }
        public override string ToString()
        {
            return this.Id.ToString();
        }

    }
}
