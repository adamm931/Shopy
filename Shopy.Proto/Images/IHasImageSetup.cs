using System.Threading.Tasks;

namespace Shopy.Proto.Images
{
    public interface IHasImageSetup<T>
    {
        Task<T> SetUpImages(ImageProvider imageProvider);
    }
}
