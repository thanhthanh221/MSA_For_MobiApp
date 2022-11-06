namespace Order.Application.Mapper
{
    public class ConfigMapper
    {
        public static Type[] RegisterMappings()
        {
            return new Type[]
            {
                typeof(OrderEntityToDtoMapper)

            };
        }
    }
}
