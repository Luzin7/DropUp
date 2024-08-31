using Gtk;

public class MainWindow : Window
{
    private readonly FileUploaderService _fileUploaderService;

    public MainWindow(FileUploaderService fileUploaderService) : base("DropUp")
    {
        _fileUploaderService = fileUploaderService;

        SetDefaultSize(400, 200);
        DeleteEvent += (o, e) => Application.Quit();

        var button = new Button("Upload File");
        button.Clicked += OnUploadButtonClicked;

        Add(button);
        ShowAll();
    }

    private async void OnUploadButtonClicked(object sender, EventArgs e)
    {
        Console.WriteLine("Upload de arquivo iniciado...");
        // Aqui você pode adicionar a lógica de upload
    }
}
