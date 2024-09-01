using Amazon.S3;
using Amazon.S3.Transfer;
using DropUp.modules.FileUploader.Repositories.Contracts;

public class FileUploaderRepositoryImplementation(IAmazonS3 s3Client, S3Config _config) : IFileUploaderRepository
{
    public async Task<string> UploadFile(string filePath)
    {
        var fileTransferUtility = new TransferUtility(s3Client);
        var fileName = Path.GetFileName(filePath);

        await fileTransferUtility.UploadAsync(filePath, _config.BucketName, fileName);
        Console.WriteLine($"Arquivo enviado com sucesso para: https://{_config.BucketName}.{_config.Endpoint}/{fileName}");
        return $"https://{_config.BucketName}.{_config.Endpoint}/{fileName}";
    }
}
