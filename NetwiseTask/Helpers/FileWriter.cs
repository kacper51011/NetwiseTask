namespace NetwiseTask.Helpers
{
    public interface IFileWriter
    {
        public Task WriteToLogFile(string logText);
    }
    public class FileWriter : IFileWriter
    {
        public async Task WriteToLogFile(string logText)
        {
            var pathOfFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataSources");

            if (!Directory.Exists(pathOfFolder))
            {
                Directory.CreateDirectory(pathOfFolder);
            }

            string filePath = Path.Combine(pathOfFolder, "Logs.txt");

            await File.AppendAllTextAsync(filePath, logText + Environment.NewLine);
        }
    }
}
