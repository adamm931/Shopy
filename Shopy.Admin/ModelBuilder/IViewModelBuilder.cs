using System.Threading.Tasks;

namespace Shopy.Admin.ModelBuilder
{
    public interface IModelBuilder<T>
    {
        Task<T> BuildAsync();
    }
}
