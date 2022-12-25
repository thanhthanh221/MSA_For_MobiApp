using Application.Common.Repository;
using CatchingRedis.Services;
using Market.Domain.CouponService.Commands;
using Market.Domain.CouponService.Model;
using Newtonsoft.Json;

namespace Market.Domain.CouponService.Service
{
    public class CouponService : ICouponService
    {
        private readonly IRepository<CouponAggregate> couponRepository;
        private readonly IReposeCacheService reposeCacheService;

        public CouponService(
            IRepository<CouponAggregate> couponRepository, IReposeCacheService reposeCacheService)
        {
            this.couponRepository = couponRepository;
            this.reposeCacheService = reposeCacheService;
        }

        public async Task<CouponAggregate> GetCouponById(Guid CouponId)
        {
            var couponInCatche = await reposeCacheService.GetCacheReponseAsync("GetCoupon_" + CouponId);

            var converCoupon = JsonConvert.DeserializeObject<CouponAggregate>(couponInCatche);
            if (converCoupon != null) { return converCoupon; }

            //Read Dd
            var coupon = await couponRepository.GetByIdAsync(CouponId);
            if (coupon is null) { return null; }

            //Update Catche
            await reposeCacheService.SetCacheReponseAsync($"GetCoupon_{CouponId}", coupon, new TimeSpan());

            return coupon;
        }

        public async Task<List<CouponAggregate>> GetAllCoupon()
        {
            var allCouponInCatche = await reposeCacheService.GetAllCacheReponseAsync("GetCoupon_");
            var converCoupon = allCouponInCatche.Select(cou => {
                return JsonConvert.DeserializeObject<CouponAggregate>(cou);
            });

            if (converCoupon != null) { return converCoupon.ToList(); }

            List<CouponAggregate> allCoupon = (await couponRepository.GetAllAsync()).ToList();

            if (allCoupon is null) { return null; }

            //Update Catche
            allCoupon.ForEach(async cou => {
                await reposeCacheService.SetCacheReponseAsync("GetCoupon_" + cou.Id, cou, new TimeSpan());
            });

            return allCoupon;
        }

        public async Task<CouponAggregate> CreateCoupon(CreateCouponCommand createCoupon)
        {
            DateTime dateCreate = new(createCoupon.Day, createCoupon.Month, createCoupon.Year);
            CouponAggregate coupon = new(createCoupon.Name, createCoupon.Description, createCoupon.Value, createCoupon.MinPriceOrder, createCoupon.MoneyIsReduced, createCoupon.Quantity, dateCreate);

            await couponRepository.CreateAsync(coupon);

            //UpdateCatche
            await reposeCacheService.SetCacheReponseAsync($"GetCoupon_{coupon.Id}", coupon, new TimeSpan());

            return coupon;
        }

        public async Task UserSaveCoupon(UserSaveCouponCommand userSaveCoupon)
        {
            var coupon = await couponRepository.GetByIdAsync(userSaveCoupon.CouponId);

            if (coupon is null || coupon.Quantity == 0) { return; }

            coupon.SetQuantityCoupon(coupon.Quantity - 1);
            await couponRepository.UpdateAsync(coupon);
            
        }
    }
}
