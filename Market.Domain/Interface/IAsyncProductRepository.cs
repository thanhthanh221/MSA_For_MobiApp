using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Interface
{
    public interface IAsyncProductRepository<T> : IAsyncRepository<T> where T : class
    {

    }
}
