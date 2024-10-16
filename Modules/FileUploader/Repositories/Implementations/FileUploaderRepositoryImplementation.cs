using Amazon.S3;
using Amazon.S3.Transfer;
using DropUp.modules.FileUploader.Repositories.Contracts;

public class FileUploaderRepositoryImplementation(IAmazonS3 s3Client, S3Config _config) : IFileUploaderRepository
{
    public async Task<string> UploadFile(string filePath)
    {
        var fileTransferUtility = new TransferUtility(s3Client);
        string fileName = Path.GetFileName(filePath);

        await fileTransferUtility.UploadAsync(filePath, _config.BucketName, fileName);

        string downloadUrl = s3Client.GeneratePreSignedURL(_config.BucketName, fileName, DateTime.UtcNow.Add(TimeSpan.FromMinutes(1)), null);
        Console.WriteLine($"Arquivo enviado com sucesso para: {downloadUrl}");
        return $"{downloadUrl}";

    }
}
