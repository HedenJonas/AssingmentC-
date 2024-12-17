using Business.Interfaces;

namespace Business.Services;

internal class FileService : IFileService
{
    private readonly string _directoryPath;
    private readonly string _filePath;

    public FileService(string directortyPath = "Data", string fileName = "list.json")
    {
        _directoryPath = directortyPath;
        _filePath = Path.Combine(_directoryPath, fileName);
    }

    public void SaveContentToFile(string content)
    {
        if (!string.IsNullOrEmpty(content))
        {
            if (!Directory.Exists(_directoryPath))
                Directory.CreateDirectory(_directoryPath);

            File.WriteAllText(_filePath, content);
        }
    }

    public string? GetContentFromFile()
    {
        if (File.Exists(_filePath))
            return File.ReadAllText(_filePath);

        return null;
    }
}
