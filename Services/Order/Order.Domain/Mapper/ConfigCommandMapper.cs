

namespace Order.Domain.Mapper
{
    public class ConfigCommandMapper
    {
        public static Type[] RegisterMappings()
        {
            return new Type[]
            {
                typeof(ItemCommandToEventMapper)
            };
        }
    }
}
