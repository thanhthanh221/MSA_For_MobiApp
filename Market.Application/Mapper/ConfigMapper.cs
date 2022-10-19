using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Mapper
{
    public class ConfigMapper
    {
        public static Type[] RegisterMappings()
        {
            return new Type[]
            {
                //Product Mapper
                typeof(ProductEntityToDtoMapper),
                typeof(ProductDtoToCommandMapper)
            };
        }
    }
}
