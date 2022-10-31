using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Domain.Validations.CategoryValidation;

namespace Market.Domain.Commands.CategoryCommand
{
    public class CategoryDeleteCommand : CategoryCommand
    {
        public CategoryDeleteCommand(Guid Id)
        {
            this.Id = Id;
        }

        public override bool IsValid()
        {
            ValidationResult = new CategoryDeleteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
