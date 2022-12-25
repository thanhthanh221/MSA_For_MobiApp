namespace Application.Common.Helper
{
    public static class PagingHelper
    {
        public static List<object> PagingEntity(List<object> obj, int page, int pageSize)
        {
            return obj.Skip(page * pageSize).Take(pageSize).ToList();
        }
    }
}