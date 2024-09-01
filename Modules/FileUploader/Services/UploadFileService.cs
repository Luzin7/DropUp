using DropUp.modules.FileUploader.Repositories.Contracts;

public class UploadFileService(IFileUploaderRepository fileUploaderRepository)
{
    private readonly IFileUploaderRepository _fileUploaderRepository = fileUploaderRepository;

    public async void Execute(string filename)
    {
        Console.WriteLine($"Uploading {filename}...");
        await _fileUploaderRepository.UploadFile(filename);
    }
}
