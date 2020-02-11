using System.Threading.Tasks;

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

        public static async Task<TDestination> MapToAsync<TDestination>(this object source)
        {
            return await Task.Run(() => source.MapTo<TDestination>());
        }
    }
}
