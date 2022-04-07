using System.IO;

namespace TestsGenerator.Models.FileSystem
{
    public static class FileReader
    {
        public static string ReadContent(string fileName)
            => !File.Exists(fileName)
                ? string.Empty
                : File.ReadAllText(fileName);
    }
}