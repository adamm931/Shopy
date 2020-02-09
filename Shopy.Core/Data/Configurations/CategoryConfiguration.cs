using Shopy.Core.Domain.Entitties;
using System.Data.Entity.ModelConfiguration;

namespace Shopy.Core.Data.Configurations
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
        }
    }
}