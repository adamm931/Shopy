using Shopy.Core.Domain.Entitties.Base;
using System.Data.Entity.ModelConfiguration;

namespace Shopy.Core.Data.Configurations
{
    public class EnumEntityConfiguration<TEntity, TEnum> : EntityTypeConfiguration<TEntity>
        where TEntity : EnumEntity<TEnum>
        where TEnum : struct
    {
        public EnumEntityConfiguration()
        {
        }
    }
}
