using Amazon.S3;

public class S3Client
{
  private readonly IAmazonS3 _s3Client;
  private readonly S3Config _config;

  public S3Client(S3Config config)
  {
    _config = config;

    var clientConfig = new AmazonS3Config
    {
      ServiceURL = $"https://{_config.Endpoint}",
      ForcePathStyle = true,
    };

    _s3Client = new AmazonS3Client(_config.AccessKey, _config.SecretKey, clientConfig);
  }

  public IAmazonS3 s3Client => _s3Client;
}