namespace Application.Common.Helper
{
    public static class PagingHelper
    {
        public static List<T> PagingEntity<T>(List<T> obj, int page, int pageSize) where T: class
        {
            return obj.Skip(page * pageSize).Take(pageSize).ToList();
        }
    }
}