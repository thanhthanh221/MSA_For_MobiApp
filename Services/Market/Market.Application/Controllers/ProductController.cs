using Market.Domain.Commands.CreateProduct;
using Market.Domain.Commands.DeleteProduct;
using Market.Domain.Commands.UpdatePriceProduct;
using Market.Domain.Commands.UpdateQuantityProduct;
using Market.Domain.Queries.ProductByCategory;
using Market.Infra.Redis;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Market.Application.Controllers
{
    [Route("MarketService/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> logger;
        private readonly IMediator mediator;

        public ProductController(ILogger<ProductController> logger, IMediator mediator)
        {
            this.logger = logger;
            this.mediator = mediator;
        }

        [Route("ProductByCategoryId/{CategoryId}")]
        [HttpGet]
        public async Task<ActionResult> GetByCategoryIdAsync(int Page, Guid CategoryId)
        {
            try {
                if(!ModelState.IsValid)
                {
                    return this.BadRequest();
                }
                ProductByCategoryQuery productQuery = new(CategoryId, Page,
                    PatternCatcheRedis.ProductPattern
                );

                var product = await mediator.Send(productQuery);

                if(product is null)
                {
                    return this.BadRequest();
                }
       
                logger.LogInformation("Try vấn thông tin sản phẩm tại {time}", DateTimeOffset.Now);
                return this.Ok(product);
            }
            catch (System.Exception) {
                logger.LogError("500");
                throw;
            }
        }
        [Route("ByProductId/{ProductId}")]
        [HttpGet]
        public async Task<ActionResult> GetByIdAsync(Guid ProductId)
        {
            try {

                return this.Ok();
            }
            catch (System.Exception) {
                logger.LogError("500");
                throw;
            }
        }

        [Route("CreateProduct")]
        [HttpPost]
        public async Task<ActionResult> CreateProductAsync([FromForm] CreateProductCommand createProduct)
        {
            try {
                if (!ModelState.IsValid) {
                    return this.NotFound();
                }
                var product = await mediator.Send(createProduct);

                if (product is null) {
                    return this.BadRequest();
                }

                return this.CreatedAtAction("CreateProductAsync", product);
            }
            catch (System.Exception) {
                logger.LogError("500");
                throw;
            }
        }
        [Route("Quantity/{ProductId}")]
        [HttpPut]
        public async Task<ActionResult> UpdateQuantityProductAsync([FromForm] UpdateQuantityProductCommand updateQuantityProduct)
        {
            try {
                if (!ModelState.IsValid) {
                    return this.BadRequest();
                }
                var checkUpdateQuantityProduct = await mediator.Send(updateQuantityProduct);

                return checkUpdateQuantityProduct ? this.NoContent() : this.BadRequest();
            }
            catch (System.Exception) {
                logger.LogError("500");
                throw;
            }
        }
        
        [Route("Price/{ProductId}")]
        [HttpPut]
        public async Task<ActionResult> UpdatePriceProductAsync([FromForm] UpdatePriceProductCommand updatePriceProduct)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return this.BadRequest();
                }
                var checkUpdatePriceProduct = await mediator.Send(updatePriceProduct);

                return checkUpdatePriceProduct? this.Ok() : this.BadRequest();
            }
            catch (System.Exception)
            {
                logger.LogWarning("Bug 500");
                throw;
            }
        }

        [Route("DeleteProduct/{ProductId}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteAsync([FromForm] DeleteProductCommand deleteProduct)
        {
            try {
                if (!ModelState.IsValid) {
                    return this.NotFound();
                }
                var checkRemoveProduct = await mediator.Send(deleteProduct);
                return checkRemoveProduct ? this.Ok() : this.NotFound();
            }
            catch (System.Exception) {
                logger.LogWarning("Bug 500");
                throw;
            }
        }
    }
}
