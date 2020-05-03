using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopy.Web
{
    public class ReflectionHelper
    {
        public static IEnumerable<TType> GetTypesFromAssembly<TTSourceAssembly, TType>()
        {
            return typeof(TTSourceAssembly).Assembly
                .GetExportedTypes()
                .Where(type => typeof(TType).IsAssignableFrom(type))
                .Select(profile => Activator.CreateInstance(profile))
                .Cast<TType>();
        }
    }
}
