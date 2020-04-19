using Shopy.Core.Files;
using System.IO;

namespace Shopy.Infrastructure.Files
{
    public class FileProvider : IFileProvider
    {
        public void Move(string source, string destination)
        {
            if (File.Exists(destination))
            {
                File.Delete(destination);
            }

            File.Move(source, destination);
        }
    }
}
