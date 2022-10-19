using Market.Application.Dtos;
using Market.Application.Interfaces;
using Market.Domain.Model;
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
            return Ok(productGetDtos);
        }
        [HttpGet("Id", Name = "GetByIdProduct")]
        public async Task<ActionResult> GetAsyncById(Guid Id)
        {
            ProductReadDto productDto = await productServices.GetById(Id); 
            if(!ModelState.IsValid ||  productDto is null)
            {
                return NotFound();
            }
            return Ok(productDto);
        }
        
        [HttpPost(Name = "PostProduct")]
        public async Task<ActionResult> PostAsync([FromForm] ProductWriteDto productDto)
        {
            if(!ModelState.IsValid)
            {
                return NotFound();
            }
            await productServices.RegisterAsync(productDto);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(Guid Id)
        {
            await productServices.DeleteAsync(Id);
            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromForm]ProductWriteDto productDto, Guid Id)
        {
            if(!ModelState.IsValid)
            {
                return NotFound();
            }
            await productServices.UpdateAsync(productDto, Id);
            return NoContent();
        }
    }
}
