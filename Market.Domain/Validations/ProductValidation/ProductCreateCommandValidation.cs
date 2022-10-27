using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Domain.Commands;
using Market.Domain.Commands.ProductCommand;

namespace Market.Domain.Validations.ProductValidation
{
    public class ProductCreateCommandValidation : ProductValidation<ProductCreateCommand>
    {
        public ProductCreateCommandValidation()
        {
            ValidateName();
            ValidateId();
        }

    }
}
