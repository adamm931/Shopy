using System.Net.Http;
using System.Threading.Tasks;

namespace Shopy.Application.Services
{
    public interface IFileUploader
    {
        Task UploadFile(HttpRequestMessage currentRequest);
    }
}
