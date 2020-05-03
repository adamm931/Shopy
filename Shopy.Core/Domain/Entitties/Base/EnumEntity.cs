using Shopy.Core.Domain.Entitties.Interfaces;
using System;
using System.Collections.Generic;

namespace Shopy.Core.Domain.Entitties.Base
{
    public abstract class EnumEntity<TEnum> : Entity<TEnum>, IName
        where TEnum : Enum
    {
        public string Name { get; private set; }

        protected EnumEntity(TEnum value)
        {
            Id = value;
            Name = value.ToString();
        }

        protected EnumEntity()
        {
        }

        public static IEnumerable<TEnum> ParseIds(string comaseparatedList)
        {
            var values = comaseparatedList.Split(',');

            foreach (var value in values)
            {
                yield return (TEnum)Enum.Parse(typeof(TEnum), value);
            }
        }
    }
}
