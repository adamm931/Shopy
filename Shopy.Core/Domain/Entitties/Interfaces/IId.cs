namespace Shopy.Core.Domain.Entitties.Interfaces
{
    public interface IId<TId>
    {
        TId Id { get; }
    }
}
