namespace TestsGenerator.Models.FileSystem
{
    public static class FileChooser
    {
        public static string Choose()
        {
            var fileDialog = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = ".txt",
                Filter = "Text documents (.txt)|*.txt"
            };

            return fileDialog.ShowDialog() == false
                ? string.Empty
                : fileDialog.FileName;
        }
    }
}