using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Domain.Commands;

namespace Market.Domain.Validations
{
    public class CreateNewProductCommandValidation : ProductValidation<CreateNewProductCommand>
    {
        public CreateNewProductCommandValidation()
        {
            ValidateName();
            ValidateId();
        }

    }
}
