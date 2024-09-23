using DropUp.modules.FileUploader.Repositories.Contracts;

public class UploadFileService(IFileUploaderRepository fileUploaderRepository)
{
    private readonly IFileUploaderRepository _fileUploaderRepository = fileUploaderRepository;

    public async Task<string> Execute(string filePath)
    {
        Console.WriteLine($"Uploading {filePath}...");
        return await _fileUploaderRepository.UploadFile(filePath);
    }
}
