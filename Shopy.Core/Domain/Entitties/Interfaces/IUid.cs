using System;

namespace Shopy.Core.Domain.Entitties.Interfaces
{
    public interface IUid
    {
        Guid Uid { get; }
    }

    public static class IUidExtensions
    {
        public static bool HasUid(this IUid model, Guid uid)
        {
            return model.Uid == uid;
        }
    }

}
