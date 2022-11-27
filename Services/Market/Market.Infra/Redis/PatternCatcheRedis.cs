namespace Market.Infra.Redis
{
    public static class PatternCatcheRedis
    {
        public static readonly string ProductPattern = "GetProduct_";
        public static readonly string RepositoryPattern = "GetRepository_";
        public static readonly string CouponPattern = "GetCoupon_";
    }
}