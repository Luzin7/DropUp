public class S3Config
{
    public string AccessKey { get; set; }
    public string SecretKey { get; set; }
    public string Endpoint { get; set; }
    public string BucketName { get; set; }

    public S3Config()
    {
        AccessKey = Environment.GetEnvironmentVariable("B2_APPLICATION_KEY_ID");
        SecretKey = Environment.GetEnvironmentVariable("B2_APPLICATION_KEY");
        Endpoint = Environment.GetEnvironmentVariable("B2_ENDPOINT");
        BucketName = Environment.GetEnvironmentVariable("B2_BUCKET_NAME");
    }
}
