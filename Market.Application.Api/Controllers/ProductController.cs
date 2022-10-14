using Market.Application.Dtos;
using Market.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Market.Application.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices productServices;

        public ProductController(IProductServices productServices)
        {
            this.productServices = productServices;
        }

        [HttpGet(Name = "GetAllProduct")]
        public async Task<ActionResult> GetAllAsync()
        {
            IEnumerable<ProductReadDto> productGetDtos = await productServices.GetAllAsync();
            if (productGetDtos is null) {
                return NotFound(
                    new {
                        message = "Không có sản phẩm"
                    }
                );
            }
            if(!ModelState.IsValid)
            {
                return NotFound();
            }
            return Ok(await productServices.GetAllAsync());
        }
        [HttpGet("Id", Name = "GetByIdProduct")]
        public async Task<ActionResult> GetAsyncById(Guid Id)
        {
            return Ok();
        }
        [HttpPost(Name = "PostProduct")]
        public async Task<ActionResult> PostAsync([FromForm] ProductReadDto productDto)
        {
            return NoContent();
        }
    }
}
