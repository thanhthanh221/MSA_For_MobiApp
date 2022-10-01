using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Core.Models
{
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        public override bool Equals(object obj)
        {
            return obj is ValueObject<T>;
        }
        public override int GetHashCode()
        {
            return this.GetType().GetHashCode();
        }

    }
}
