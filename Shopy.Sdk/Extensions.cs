using System.IO;
using System.Web;

namespace Shopy.Sdk
{
    public static class Extensions
    {
        public static void EnsureSave(this HttpPostedFileBase file, string path)
        {
            var directory = Path.GetDirectoryName(path);

            Directory.CreateDirectory(directory);

            file.SaveAs(path);
        }
    }
}
