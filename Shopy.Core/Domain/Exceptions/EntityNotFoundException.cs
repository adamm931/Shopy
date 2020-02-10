using System;

namespace Shopy.Core.Domain.Exceptions
{
    public class EntityNotFoundException<TId> : LocalizedException
    {

        public EntityNotFoundException(string entityName, TId resourceId) : base("EntityNotFound", resourceId, entityName)
        {
        }
    }

    public class EntityNotFoundException : EntityNotFoundException<Guid>
    {
        public EntityNotFoundException(string entityName, Guid resourceId) : base(entityName, resourceId)
        {
        }
    }
}
