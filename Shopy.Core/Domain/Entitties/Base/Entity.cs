using Shopy.Core.Domain.Entitties.Interfaces;

namespace Shopy.Core.Domain.Entitties.Base
{
    public abstract class Entity : Entity<int>
    {
    }

    public abstract class Entity<TId> : IId<TId>
    {
        public TId Id { get; protected set; }
    }
}
