using Market.Application.Dtos;
using Market.Application.Interfaces;
using Market.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Market.Application.Api.Controllers
{
    [Route("Market/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices productServices;
        private readonly ILogger<ProductController> logger;

        public ProductController(IProductServices productServices, ILogger<ProductController> logger)
        {
            this.productServices = productServices;
            this.logger = logger;
        }

        [HttpGet(Name = "GetAllProduct")]
        public async Task<ActionResult> GetAllAsync()
        {
            try {
                IEnumerable<ProductReadDto> productGetDtos = await productServices.GetAllAsync();
                if (productGetDtos is null) {
                    return NotFound(
                        new {
                            message = "Không có sản phẩm"
                        }
                    );
                }
                if (!ModelState.IsValid) {
                    return NotFound();
                }
                logger.LogInformation("Try vấn thông tin sản phẩm tại {time}", DateTimeOffset.Now);
                return Ok(productGetDtos);
            }
            catch (System.Exception) {
                logger.LogError("500");
                throw;
            }
        }
        [HttpGet("Id", Name = "GetByIdProduct")]
        public async Task<ActionResult> GetAsyncById(Guid Id)
        {
            try {
                ProductReadDto productDto = await productServices.GetByIdAsync(Id);
                if (!ModelState.IsValid || productDto is null) {
                    return NotFound();
                }
                return Ok(productDto);
            }
            catch (System.Exception) {
                logger.LogError("500");
                throw;
            }
        }

        [HttpPost(Name = "PostProduct")]
        public async Task<ActionResult> PostAsync([FromForm] ProductWriteDto productDto)
        {
            try {
                if (!ModelState.IsValid) {
                    return NotFound();
                }
                await productServices.CreateAsync(productDto);
                return NoContent();
            }
            catch (System.Exception) {
                logger.LogError("500");
                throw;
            }
        }

        [HttpDelete("Id")]
        public async Task<ActionResult> DeleteAsync(Guid Id)
        {
            await productServices.DeleteAsync(Id);
            return NoContent();
        }
        [HttpPut("Id",Name= "PustProduct")]
        public async Task<ActionResult> UpdateAsync([FromForm] ProductWriteDto productDto, Guid Id)
        {
            try {
                if (!ModelState.IsValid) {
                    return NotFound();
                }
                await productServices.UpdateAsync(productDto, Id);
                return NoContent();
            }
            catch (System.Exception) {
                logger.LogError("500");
                throw;
            }
        }
    }
}
