using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Domain.Core.Models;
using Market.Domain.Model;

namespace Market.Domain.Interface
{
    public interface IAsyncProductRepository : IAsyncRepository<Product>
    {

    }
}
