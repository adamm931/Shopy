using Shopy.Core.Domain.Entitties.Base;
using Shopy.Core.Domain.Entitties.Interfaces;
using System;
using System.Collections.Generic;

namespace Shopy.Core.Domain.Entitties
{
    public class Category : NameEntity, IUid
    {
        public Guid Uid { get; private set; }

        public ICollection<Product> Products { get; private set; }

        public Category(string name) : base(name)
        {
            Uid = Guid.NewGuid();
            Products = new List<Product>();
        }

        private Category()
        {
        }
    }
}