using Market.Domain.Commands;

namespace Market.Domain.Validations
{
    public class DeleteProductCommandValidation : ProductValidation<DeleteProductCommand>
    {
        public DeleteProductCommandValidation()
        {
            ValidateId();
        }
    }
}