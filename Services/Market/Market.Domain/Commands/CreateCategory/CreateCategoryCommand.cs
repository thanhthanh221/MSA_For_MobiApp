using MediatR;
using Microsoft.AspNetCore.Http;

namespace Market.Domain.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public List<Guid> ParentId { set; get; }
        public IFormFile Image { get; set; }
    }
}