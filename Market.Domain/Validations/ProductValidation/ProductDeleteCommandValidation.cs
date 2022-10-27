using Market.Domain.Commands;
using Market.Domain.Commands.ProductCommand;

namespace Market.Domain.Validations.ProductValidation
{
    public class ProductDeleteCommandValidation : ProductValidation<ProductDeleteCommand>
    {
        public ProductDeleteCommandValidation()
        {
            ValidateId();
        }
    }
}