namespace DropUp.Domain.Interfaces
{
    public interface IFileUploaderService
    {
        Task<string> UploadFileAsync(string filePath);
    }
}
