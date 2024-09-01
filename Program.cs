using Gtk;
using DotNetEnv;
using DropUp.UI;

class Program
{
    static void Main(string[] args)
    {
        Env.Load();

        var s3Config = new S3Config();
        var s3Client = new S3Client(s3Config);
        var fileUploaderRepository = new FileUploaderRepositoryImplementation(s3Client.s3Client, s3Config);
        var uploadFileService = new UploadFileService(fileUploaderRepository);

        Application.Init();
        var win = new MainWindow(uploadFileService);
        Application.Run();
    }
}
