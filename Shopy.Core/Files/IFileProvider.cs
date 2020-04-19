namespace Shopy.Core.Files
{
    public interface IFileProvider
    {
        void Move(string source, string destination);
    }
}
