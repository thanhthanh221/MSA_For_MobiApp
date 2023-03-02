using Application.Common.Extensions;
using Market.Coupon.Domain.Commands.CreateCoupon;
using Market.Coupon.Domain.Commands.UserSaveCoupon;
using Market.Coupon.Domain.Events.UpdateCache;
using Market.Coupon.Domain.Interfaces;
using Market.Coupon.Domain.Model;
using Market.Coupon.Domain.Query.FilterAllCoupon;
using Market.Coupon.Domain.Query.FilterCouponByUserId;
using Market.Coupon.Domain.Query.FindCouponById;
using Market.Coupon.Domain.Services;
using MediatR;

namespace Market.Coupon.Api.Installers
{
    public class DomainInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            //Services
            services.AddScoped<ICouponManager, CouponManager>();

            //Command
            services.AddScoped<IRequestHandler<CreateCouponCommand, CouponAggregate>, CreateCouponHandler>();
            services.AddScoped<IRequestHandler<UserSaveCouponCommand, UserSaveCouponReturn>, UserSaveCouponHandler>();

            // Query
            services.AddScoped<IRequestHandler<FindCouponByIdQuery, CouponAggregate>, FindCouponByIdHandler>();
            services.AddScoped<IRequestHandler<FindCouponByUserIdQuery, List<CouponAggregate>>, FindCouponByUserIdHandler>();
            services.AddScoped<IRequestHandler<FilterAllCouponQuery, List<CouponAggregate>>, FilterAllCouponHandler>();


            // Event
            services.AddScoped<INotificationHandler<UpdateCacheEvent>, UpdateCacheHandler>();

        }
    }
}
