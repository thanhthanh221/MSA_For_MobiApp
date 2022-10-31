using Market.Domain.Commands;
using Market.Domain.Commands.ProductCommand;

namespace Market.Domain.Validations.ProductValidation
{
    public class ProductUpdateCommandValidation : ProductValidation<ProductUpdateCommand>
    {
        public ProductUpdateCommandValidation()
        {
        }
    }
}