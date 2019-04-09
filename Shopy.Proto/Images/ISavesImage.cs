using System.Threading.Tasks;

namespace Shopy.Proto.Images
{
    public interface ISavesImage
    {
        Task SaveImageAsync(ImageProvider imageProvider);
    }
}
