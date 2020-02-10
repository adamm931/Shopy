using Shopy.Core.Domain.Entitties.Interfaces;
using System;

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
    }
}
