using Application.Common.Repository;
using CatchingRedis.Services;
using Market.Coupon.Domain.Events.UpdateCache;
using Market.Coupon.Domain.Model;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Market.Coupon.Domain.Commands.CreateCoupon
{
    public class CreateCouponHandler : IRequestHandler<CreateCouponCommand, CouponAggregate>
    {
        private readonly IRepository<CouponAggregate> couponRepository;
        private readonly ILogger<CreateCouponHandler> logger;
        private readonly IMediator mediator;

        public CreateCouponHandler(
            IRepository<CouponAggregate> couponRepository, ILogger<CreateCouponHandler> logger, IMediator mediator)
        {
            this.couponRepository = couponRepository;
            this.logger = logger;
            this.mediator = mediator;
        }

        public async Task<CouponAggregate> Handle(CreateCouponCommand createCoupon, CancellationToken cancellationToken)
        {
            DateTime dateCreate = new(createCoupon.Year, createCoupon.Month, createCoupon.Day);

            if (dateCreate.CompareTo(DateTime.UtcNow) < 0) { return null; }
            CouponAggregate coupon = new(
                createCoupon.Name,
                createCoupon.Description,
                createCoupon.Value,
                createCoupon.MinPriceOrder,
                createCoupon.MoneyIsReduced,
                createCoupon.Quantity,
                dateCreate);

            logger.LogInformation("Tạo 1 Mã giảm giá {Id} - {Name}", coupon.Id, coupon.Name);
            await couponRepository.CreateAsync(coupon);
            await mediator.Publish(new UpdateCacheEvent(), cancellationToken);

            return coupon;
        }
    }
}