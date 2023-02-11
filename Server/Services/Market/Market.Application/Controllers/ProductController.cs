using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Market.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> logger;
        private readonly IQueryProduct queryProduct;
        private readonly IMediator mediator;

        public ProductController(
            ILogger<ProductController> logger, IQueryProduct queryProduct, IMediator mediator)
        {
            this.logger = logger;
            this.queryProduct = queryProduct;
            this.mediator = mediator;
        }

        [Route("ProductByCategoryId/{CategoryId}")]
        [HttpGet]
        public async Task<ActionResult> GetByCategoryIdAsync(Guid categoryId, int page, int pageSize)
        {
            try {
                if (!ModelState.IsValid) {
                    return this.BadRequest();
                }
                logger.LogInformation("Try vấn thông tin sản phẩm tại {time}", DateTimeOffset.Now);
                return this.Ok();
            }
            catch (System.Exception) {
                logger.LogError("500");
                throw;
            }
        }
        [Route("FilerProduct")]
        [HttpGet]
        public async Task<ActionResult> GetProductAsync([FromForm] FilterRequest filterRequest)
        {
            try {
                var products = queryProduct.FilterByRequestQuery(filterRequest);

                if (products is null) { return this.BadRequest(); }
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
                var product = await queryProduct.FilterById(ProductId);
                if (product is null) { return this.BadRequest(); }
                return this.Ok(product);
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

    }
}
