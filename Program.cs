using Gtk;
using Amazon.S3;

class Program
{
    static void Main(string[] args)
    {
        var s3Client = new AmazonS3Client();
        var s3FileUploaderAdapter = new S3FileUploaderAdapter(s3Client, "your-bucket-name");
        var fileUploaderService = new FileUploaderService(s3FileUploaderAdapter);

        Application.Init();
        var win = new MainWindow(fileUploaderService);
        Application.Run();
    }
}
