using System.IO;

namespace Core.Services
{
    public interface IFilePathProvider
    {
        string GetConfigDirectory();
    }

    public class FilePathProvider : IFilePathProvider
    {
        public string GetConfigDirectory()
        {
            return Directory.GetCurrentDirectory() + "\\Configs";
        }
    }
}