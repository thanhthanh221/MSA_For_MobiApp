using Market.Application.Extensions;
using Market.Domain.Commands.CreateProduct;
using Market.Domain.Commands.DeleteProduct;
using Market.Domain.Commands.UpdatePriceProduct;
using Market.Domain.Queries.FilterProduct;
using Market.Domain.Queries.ProductByCategory;
using Market.Domain.Queries.ProductById;
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
                if (!ModelState.IsValid) {
                    return this.BadRequest();
                }
                ProductByCategoryQuery productQuery = new(CategoryId, Page,
                    PatternCatcheRedis.ProductPattern
                );

                var products = await mediator.Send(productQuery);

                if (products is null) {
                    return this.BadRequest();
                }

                logger.LogInformation("Try vấn thông tin sản phẩm tại {time}", DateTimeOffset.Now);
                return this.Ok(products);
            }
            catch (System.Exception) {
                logger.LogError("500");
                throw;
            }
        }
        [Route("FilerProduct")]
        [HttpGet]
        public async Task<ActionResult> GetProductAsync([FromQuery] FilterProductQuery query)
        {
            try {
                var products = await mediator.Send(query);

                if (products is null) {
                    return this.BadRequest();
                }

                return this.Ok(products);
            }
            catch (System.Exception) {
                logger.LogError("500");
                throw;
            }
        }

        [Route("ProductById/{ProductId}")]
        [HttpGet]
        public async Task<ActionResult> GetProductByIdAsync(Guid ProductId)
        {
            try {
                ProductByIdQuery productByIdQuery = new(ProductId);
                var product = await mediator.Send(productByIdQuery);

                if (product is null) {
                    return this.BadRequest();
                }
                return this.Ok(product.ConvertOneToDto(product.UserId));
            }
            catch (System.Exception) {
                logger.LogError("500");
                throw;
            }
        }

        [Route("CreateProduct")]
        [HttpPost]
        public async Task<ActionResult> CreateProductAsync(
            [FromForm] CreateProductCommand createProduct)
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
        [Route("Price/{ProductId}")]
        [HttpPut]
        public async Task<ActionResult> UpdatePriceProductAsync([FromForm] UpdatePriceProductCommand updatePriceProduct)
        {
            try {
                if (!ModelState.IsValid) {
                    return this.BadRequest();
                }
                var checkUpdatePriceProduct = await mediator.Send(updatePriceProduct);

                return checkUpdatePriceProduct ? this.Ok() : this.BadRequest();
            }
            catch (System.Exception) {
                logger.LogWarning("Bug 500");
                throw;
            }
        }

        [Route("DeleteProduct/{ProductId}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteProductAsync([FromForm] DeleteProductCommand deleteProduct)
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
