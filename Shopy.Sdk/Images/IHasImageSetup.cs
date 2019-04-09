using System.Threading.Tasks;

namespace Shopy.SDK.Images
{
    public interface IHasImageSetup<T>
    {
        Task<T> SetUpImages(ImageProvider imageProvider);
    }
}
