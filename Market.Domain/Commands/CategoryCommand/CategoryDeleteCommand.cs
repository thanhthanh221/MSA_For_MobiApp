using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }
    }
}
