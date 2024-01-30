namespace Products.Infrastructure.Services;

public class FileService : IFileService
{
    public async Task CreateFile(IFormFile file, string directory, string fileName)
    {
        if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

        await using var stream = new FileStream(Path.Combine(directory, fileName), FileMode.Create);
        await file.CopyToAsync(stream);
    }

    public void DeleteFile(string directory, string fileName)
    {
        var destination = Path.Combine(directory, fileName);

        if (File.Exists(destination)) File.Delete(destination);
    }
}