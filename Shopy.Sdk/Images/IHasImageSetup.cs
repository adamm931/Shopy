using System.Threading.Tasks;

namespace Shopy.Sdk.Images
{
    public interface IHasImageSetup<T>
    {
        Task<T> SetUpImages(ImageProvider imageProvider);
    }
}
