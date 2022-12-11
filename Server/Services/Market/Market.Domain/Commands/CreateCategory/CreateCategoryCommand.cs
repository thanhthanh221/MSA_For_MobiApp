using Market.Domain.Model;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Market.Domain.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<Category>
    {
        [Required]
        public string Name { get; set; }
        public HashSet<Guid> ParentId { set; get; }
        [Required]
        public IFormFile Image { get; set; }
    }
}