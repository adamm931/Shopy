using Shopy.Core.Domain.Entitties;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Shopy.Core.Data
{
    public interface IShopyContext : IDisposable
    {
        IDbSet<Product> Products { get; }

        IDbSet<Category> Categories { get; }

        IDbSet<SizeType> SizeTypes { get; }

        IDbSet<BrandType> BrandTypes { get; }

        Task Save();
    }
}
