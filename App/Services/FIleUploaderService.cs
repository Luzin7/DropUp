using DropUp.Domain.Interfaces;

public class FileUploaderService : IFileUploaderService
{
    private readonly IFileUploaderService _fileUploaderAdapter;

    public FileUploaderService(IFileUploaderService fileUploaderAdapter)
    {
        _fileUploaderAdapter = fileUploaderAdapter;
    }

    public Task<string> UploadFileAsync(string filePath)
    {
        return _fileUploaderAdapter.UploadFileAsync(filePath);
    }
}
