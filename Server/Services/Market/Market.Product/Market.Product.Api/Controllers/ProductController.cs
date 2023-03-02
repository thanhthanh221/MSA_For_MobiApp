using System.ComponentModel.DataAnnotations;
using Application.Common.Helper;
using Application.Common.Utils;
using Market.Product.Api.Dtos;
using Market.Product.Domain.Commands.CreateProduct;
using Market.Product.Domain.Commands.RemoveProduct;
using Market.Product.Domain.Commands.UserFavouriteProduct;
using Market.Product.Domain.Queries.FindProductByCategory;
using Market.Product.Domain.Queries.FindProductById;
using Market.Product.Domain.Queries.SearchProduct;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Market.Product.Api.Controllers
{
    [Route("ProductService/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(
            IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("ProductFile/{productImageName}")]
        public async Task<ActionResult> ProductImageAsync(string productImageName)
        {
            try {
                string imageProductPath = $"Images/{productImageName}";
                var bytesImage = await System.IO.File.ReadAllBytesAsync(imageProductPath);
                var fileExtension = UploadFileHelper.GetFileExtension(productImageName);
                string mimetype = UploadFileHelper.GetImageMimeTypeFromImageFileExtension(fileExtension);
                return this.File(bytesImage, mimetype);
            }
            catch (Exception ex) {
                return this.StatusCode(500, new ApiResponseUtils(false, ex.Message));
            }
        }
        [HttpGet]
        [Route("GetById/{ProductId}")]
        public async Task<ActionResult> GetProductByIdAsync([Required] Guid ProductId)
        {

            if (!ModelState.IsValid) { return this.BadRequest(); }
            ProductByIdQuery query = new() { ProductId = ProductId };
            var product = await mediator.Send(query);
            if (product is null) {
                return this.Ok(new ApiResponseUtils(false, "Không tìm thấy sản phẩm"));
            }
            return this.Ok(new ApiResponseUtils(true, "Tìm thấy sản phẩm", product));

        }
        [HttpGet]
        [Route("GetByCategoryId")]
        public async Task<ActionResult> GetProductByCategoryAsync([FromQuery] ProductByCategoryQuery query, Guid? userId)
        {
            try {
                var products = await mediator.Send(query);
                if (products is null) { return this.Ok(new ApiResponseUtils(false, "Không tìm thấy sản phẩm")); }
                // Conver To Dto
                List<ProductsDto> productsDto = products.Select(p => ProductsDto.ConverProductToDto(p, userId)).ToList();
                var PagingProduct = PagingHelper.PagingEntity(productsDto.ToList(), query.Page, query.PageSize);
                return this.Ok(new ApiResponseUtils(true, "Tìm thấy sản phẩm", PagingProduct));
            }
            catch (Exception ex) {
                return this.StatusCode(500, new ApiResponseUtils(false, ex.Message));
            }
        }
        [HttpGet]
        [Route("SearchProduct")]
        public async Task<ActionResult> SearchProductAsync([FromQuery] SearchProductQuery query, Guid? userId)
        {
            try {
                if (!ModelState.IsValid) { return this.BadRequest(); }
                var products = await mediator.Send(query);
                if (products is null) {
                    return this.Ok(new ApiResponseUtils(false, "Không tìm thấy sản phẩm"));
                }
                var productsDto = products.Select(p => ProductsDto.ConverProductToDto(p, userId));
                return this.Ok(new ApiResponseUtils(true, "Tìm thấy sản phẩm", productsDto));
            }
            catch (Exception ex) {
                return this.StatusCode(500, new ApiResponseUtils(false, ex.Message));
            }
        }
        [HttpPost("CreateProduct")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult> CreateProductAsync([FromForm] CreateProductCommand createProductCommand)
        {
            try {
                if (!ModelState.IsValid) { return this.BadRequest(); }
                var product = await mediator.Send(createProductCommand);
                if (product is null) {
                    return this.Ok(new ApiResponseUtils(false, "Không tạo được sản phẩm", null));
                }
                return this.CreatedAtAction(nameof(CreateProductAsync), product);
            }
            catch (Exception ex) {
                return this.StatusCode(500, ex.Message);
            }
        }

        [HttpPatch("UserFavouriteProduct")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult> UserFavouriteProductAsync(Guid ProductId, Guid UserId)
        {
            try {
                if (!ModelState.IsValid) { return this.BadRequest(); }
                var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                UserFavouriteProductCommand command = new(UserId, ProductId, token);
                await mediator.Send(command);
                return this.NoContent();
            }
            catch (Exception ex) {
                return this.StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("DeleteProduct")]
        public async Task<ActionResult> DeleteProductAsync(RemoveProductCommand command)
        {
            try {
                if (!ModelState.IsValid) { return this.BadRequest(); }
                var check = await mediator.Send(command);
                if (check) {
                    return this.Ok(new ApiResponseUtils(true, "Xóa thành công sản phẩm"));
                }
                return this.Ok(new ApiResponseUtils(false, "Không Tồn tại sản phẩm"));

            }
            catch (Exception ex) {
                return this.StatusCode(500, new ApiResponseUtils(false, ex.Message));
            }
        }
    }
}
