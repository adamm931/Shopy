using Shopy.Core.Domain.Entitties.Interfaces;

namespace Shopy.Core.Domain.Entitties.Base
{
    public class NameEntity : NameEntity<int>
    {
        public NameEntity(string name) : base(name)
        {
        }

        protected NameEntity()
        {
        }
    }

    public class NameEntity<TId> : Entity<TId>, IName
    {
        public string Name { get; private set; }

        public NameEntity(string name)
        {
            SetName(name);
        }

        protected NameEntity()
        {
        }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new NameIsEmptyException();
            }

            Name = name;
        }
    }
}
