#region Using(s)

using AutoMapper;
using Shopy.Core.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

#endregion

namespace Shopy.Core.Extensions
{
    public static class AutoMapperExtensions
    {
        #region Public Method(s)

        public static IMapperConfigurationExpression AddProfile(
            this IMapperConfigurationExpression config,
            Assembly assembly)
        {
            var profiles = assembly.GetTypesOf<Profile>();

            config.AddProfiles(profiles);

            return config;
        }

        public static TDestination MapTo<TDestination>(this object source)
        {
            return AutoMapperFactory
                .GetMapper()
                .Map<TDestination>(source);
        }

        #endregion

        #region Private Method(s)

        private static IEnumerable<TType> GetTypesOf<TType>(this Assembly assembly)
        {
            var types = assembly
                .GetTypes()
                .Where(type => type.IsOfType<TType>())
                .Select(type => Activator.CreateInstance(type))
                .Cast<TType>()
                .ToList();

            return types;
        }

        private static bool IsOfType<TType>(this Type type)
        {
            return typeof(TType).IsAssignableFrom(type);
        }

        #endregion
    }
}
