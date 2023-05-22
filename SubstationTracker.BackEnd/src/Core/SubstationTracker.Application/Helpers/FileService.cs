using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace SubstationTracker.Application.Helpers;

public class FileService
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly string _imageStoragePath;

    public FileService(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
        _imageStoragePath = _webHostEnvironment.WebRootPath + "/Storage/Images/";

        if (Directory.Exists(_imageStoragePath) is false)
            Directory.CreateDirectory(_imageStoragePath);
    }

    public bool FindAndIfExistThenDeleteFile(string path)
    {
        if (File.Exists(path))
        {
            File.Delete(path);

            return true;
        }

        string fullPath = _webHostEnvironment.WebRootPath + path;
        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);

            return true;
        }

        return false;
    }

    public async Task<string> SaveAsImage(IFormFile file, string fileName)
    {
        if (string.IsNullOrEmpty(Path.GetExtension(fileName)))
            fileName += ".jpg";

        string filePath = Path.Combine(_imageStoragePath, fileName);

        using (Stream fileStream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);

            await fileStream.DisposeAsync();
        }

        return filePath.Replace(_webHostEnvironment.WebRootPath, string.Empty);
    }
}