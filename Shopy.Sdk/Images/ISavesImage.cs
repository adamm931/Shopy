using System.Threading.Tasks;

namespace Shopy.SDK.Images
{
    public interface ISavesImage
    {
        Task SaveImageAsync(ImageProvider imageProvider);
    }
}
