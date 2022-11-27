using MediatR;

namespace Market.Domain.Commands.CreateCategory
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, bool>
    {
        public Task<bool> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
