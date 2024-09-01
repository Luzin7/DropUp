namespace DropUp.modules.FileUploader.Repositories.Contracts
{
    public interface IFileUploaderRepository
    {
        Task<string> UploadFile(string filePath);
    }
}
