namespace Market.Application.Mapper
{
    public class ConfigMapper
    {
        public static Type[] RegisterMappings()
        {
            return new Type[]
            {
                //Product Mapper
                typeof(ProductEntityToDtoMapper),
                typeof(ProductDtoToCommandMapper),

                // Category Mapper
                typeof(CategoryEntityToDtoMapper),
                typeof(CategoryDtoToCommandMapper)
            };
        }
    }
}
