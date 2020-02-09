using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopy.Core.Common
{
    public class EnumProvider
    {
        public static IEnumerable<TEnum> All<TEnum>()
        {
            return Enum.GetValues(typeof(TEnum))
                .Cast<TEnum>()
                .AsEnumerable();
        }

    }
}
