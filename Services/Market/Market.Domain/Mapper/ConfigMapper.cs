using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Mapper
{
    public class ConfigCommandMapper
    {
        public static Type[] CommandMappings()
        {
            return new Type[]
            {
                typeof(ProductCommandMapper)
            };
        }
    }
}
