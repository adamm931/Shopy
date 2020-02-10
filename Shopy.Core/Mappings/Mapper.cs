using AutoMapper;

namespace Shopy.Core.Mappings
{
    public class Mapper
    {
        private static IMapper _current;

        public static IMapper Current => _current ??= CreateMapper();

        private static IMapper CreateMapper()
            => new MapperConfiguration(config => config.AddMaps(typeof(Mapper))).CreateMapper();
    }
}
