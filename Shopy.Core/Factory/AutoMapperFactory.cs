using AutoMapper;
using Shopy.Core.Extensions;

namespace Shopy.Core.Factory
{
    public class AutoMapperFactory
    {
        private static IMapper mapper;

        public static IMapper GetMapper()
        {
            if (mapper == null)
            {
                mapper = new MapperConfiguration(config => config.AddProfile(typeof(AutoMapperFactory).Assembly))
                    .CreateMapper();
            }

            return mapper;
        }
    }
}
