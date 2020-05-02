using System.Threading.Tasks;

namespace Shopy.Sdk.Images
{
    public interface ISavesImage
    {
        Task SaveImageAsync(ImageProvider imageProvider);
    }
}
