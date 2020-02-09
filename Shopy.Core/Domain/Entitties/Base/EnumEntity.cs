using Shopy.Core.Domain.Entitties.Interfaces;

namespace Shopy.Core.Domain.Entitties.Base
{
    public abstract class EnumEntity<TEnum> : Entity<TEnum>, IName
        where TEnum : struct
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
