using Amazon.S3;
using Amazon.S3.Transfer;
using DropUp.Domain.Interfaces;

public class S3FileUploaderAdapter : IFileUploaderService
{
    private readonly IAmazonS3 _s3Client;
    private readonly string _bucketName;

    public S3FileUploaderAdapter(IAmazonS3 s3Client, string bucketName)
    {
        _s3Client = s3Client;
        _bucketName = bucketName;
    }

    public async Task<string> UploadFileAsync(string filePath)
    {
        var keyName = Path.GetFileName(filePath);
        var fileTransferUtility = new TransferUtility(_s3Client);
        await fileTransferUtility.UploadAsync(filePath, _bucketName, keyName);
        return $"https://{_bucketName}.s3.amazonaws.com/{keyName}";
    }
}
