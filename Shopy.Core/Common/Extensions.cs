using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopy.Core.Common
{
    public static class Extensions
    {
        public static void RemoveAll<TItem>(this ICollection<TItem> items, Func<TItem, bool> filter)
        {
            var listItems = items.ToList();

            foreach (var item in listItems.Where(filter))
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
