namespace Shopy.Application.Mappings
{
    public static class AutoMapperExtensions
    {
        public static TDestination MapTo<TDestination>(this object source)
        {
            return Mapper
                .Current
                .Map<TDestination>(source);
        }
    }
}
