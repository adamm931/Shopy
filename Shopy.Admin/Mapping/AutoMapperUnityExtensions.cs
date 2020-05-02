using AutoMapper;
using Unity;

namespace Shopy.Admin.Mapping
{
    public static class AutoMapperUnityExtensions
    {
        public static void RegisterAutoMapper(this IUnityContainer container)
        {
            var configuration = new MapperConfiguration(AddAdminProfile);
            var mapper = configuration.CreateMapper();

            container.RegisterInstance(mapper);
        }

        private static void AddAdminProfile(IMapperConfigurationExpression expression)
        {
            expression.AddProfile(new ShopyAdminProfile());
        }
    }
}