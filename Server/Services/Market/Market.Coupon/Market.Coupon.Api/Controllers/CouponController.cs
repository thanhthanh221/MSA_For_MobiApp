using Application.Common.Utils;
using Market.Coupon.Api.Dto;
using Market.Coupon.Domain.Commands.CreateCoupon;
using Market.Coupon.Domain.Commands.UserSaveCoupon;
using Market.Coupon.Domain.Query.FilterAllCoupon;
using Market.Coupon.Domain.Query.FilterCouponByUserId;
using Market.Coupon.Domain.Query.FindCouponById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Market.Coupon.Api.Controllers
{
    [Route("CouponService/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly IMediator mediator;

        public CouponController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        [Route("GetCouponById/{CouponId}")]
        public async Task<ActionResult> GetCouponByIdAsync(Guid CouponId)
        {
            try {
                if (!ModelState.IsValid) { return this.StatusCode(400, "Dữ liệu không hợp lệ !"); }
                var coupon = await mediator.Send(new FindCouponByIdQuery(CouponId));
                if (coupon is null) {
                    return this.Ok(new ApiResponseUtils(false, "Không tìm thấy sản phẩm phù hợp", null));
                }
                GetCouponDto couponDto = GetCouponDto.ConverEntityToDto(coupon);
                return this.Ok(new ApiResponseUtils(true, "Tìm thấy sản phẩm", couponDto));
            }
            catch (Exception ex) {
                return this.StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [Route("GetCouponById/{UserId}/{Page}/{PageSize}")]
        public async Task<ActionResult> GetCouponByUserIdAsync(Guid UserId, int Page, int PageSize)
        {
            try {
                if (!ModelState.IsValid) { return this.StatusCode(400, "Dữ liệu không hợp lệ !"); }
                var couponByUserId = await mediator.Send(new FindCouponByUserIdQuery(UserId, Page, PageSize));
                if (couponByUserId.Count == 0) {
                    return this.Ok(new ApiResponseUtils(false, "Không tìm thấy sản phẩm phù hợp", null));
                }
                var couponDto = GetAllCouponDto.ConverEntityToDto(couponByUserId);
                return this.Ok(new ApiResponseUtils(true, "Tìm thấy sản phẩm", couponDto));
            }
            catch (Exception ex) {
                return this.StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [Route("GetAllCoupon/{Page}/{PageSize}")]
        public async Task<ActionResult> GetAllCouponIdAsync(int Page, int PageSize)
        {
            try {
                if (!ModelState.IsValid) { return this.StatusCode(400, "Dữ liệu không hợp lệ !"); }
                var allCoupon = await mediator.Send(new FilterAllCouponQuery(Page, PageSize));
                if (allCoupon.Count == 0) { return this.Ok(new ApiResponseUtils(false, "Không có sản phẩm!", null)); }
                var allCouponDto = GetAllCouponDto.ConverEntityToDto(allCoupon);
                return this.Ok(new ApiResponseUtils(true, "Tìm thấy sản phẩm", allCouponDto));
            }
            catch (Exception ex) {
                return this.StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("CreateCoupon")]
        public async Task<ActionResult> CreateCouponAsync(CreateCouponCommand command)
        {
            try {
                if (!ModelState.IsValid) { return this.StatusCode(400, "Lỗi dữ liệu nhập vào"); }
                var coupon = await mediator.Send(command);
                if (coupon is null) { return this.StatusCode(400, "Không tạo được Phiếu giảm giá!"); }
                return this.StatusCode(201, coupon);
            }
            catch (Exception ex) {
                return this.StatusCode(500, ex.Message);
            }
        }
        [HttpPatch]
        [Route("UserSaveCoupon")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult> UserSaveCouponAsync(Guid UserId, Guid CouponId)
        {
            try {
                if (!ModelState.IsValid) { return this.StatusCode(400, "Lỗi dữ liệu nhập vào"); }
                var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                UserSaveCouponCommand command = new(UserId, CouponId, token);
                var coupon = await mediator.Send(command);
                return this.StatusCode(204, coupon);
            }
            catch (Exception ex) {
                return this.StatusCode(500, ex.Message);
            }
        }
    }
}
