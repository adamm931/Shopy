using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopy.Core.Common
{
    public static class Extensions
    {
        public static void RemoveAll<TItem>(this ICollection<TItem> items, Func<TItem, bool> filter)
        {
            foreach (var item in items.Where(filter))
            {
                items.Remove(item);
            }
        }

        public static IEnumerable<TEnum> All<TEnum>(this Enum @enum)
        {
            return Enum.GetValues(@enum.GetType())
                .Cast<TEnum>()
                .AsEnumerable();
        }

        public static IEnumerable<TItem> Randomize<TItem>(this IEnumerable<TItem> items)
        {
            return items.OrderBy(item => Guid.NewGuid());
        }
    }
}
