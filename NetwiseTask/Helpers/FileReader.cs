using System.Text;

namespace NetwiseTask.Helpers
{
    public interface IFileReader
    {
        public Task<string> ReadLogs();
    }
    public class FileReader : IFileReader
    {
        public async Task<string> ReadLogs()
        {
            var pathOfFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataSources");

            if (!Directory.Exists(pathOfFolder))
            {
                return "Directory does not exists";
            }

            string filePath = Path.Combine(pathOfFolder, "Logs.txt");

            if (!File.Exists(filePath))
            {
                return "Cat Facts logs file is currently empty";
            }
            return await File.ReadAllTextAsync(filePath);
        }
    }
}
