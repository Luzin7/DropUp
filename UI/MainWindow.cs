using Gtk;

namespace DropUp.UI
{
    public class MainWindow : Window
    {
        private readonly UploadFileService _uploadFileService;

        public MainWindow(UploadFileService uploadFileService) : base("DropUp")
        {
            _uploadFileService = uploadFileService;

            SetDefaultSize(400, 200);
            DeleteEvent += (o, e) => Application.Quit();

            var button = new Button("Upload File");

            button.Clicked += OnUploadButtonClicked;

            Add(button);
            ShowAll();
        }

        private void OnUploadButtonClicked(object? sender, EventArgs e)
        {
            using var fileChooser = new FileChooserDialog(
                 "Select a file",
                 this,
                 FileChooserAction.Open,
                 "Cancel", ResponseType.Cancel,
                 "Open", ResponseType.Accept);
            if (fileChooser.Run() == (int)ResponseType.Accept)
            {
                string filePath = fileChooser.Filename;
                UploadFile(filePath);
            }
            fileChooser.Destroy();
        }

        private void UploadFile(string filePath)
        {
            Console.WriteLine(filePath);

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
                return;
            }

            try
            {
                using var fileStream = File.OpenRead(filePath);
                string fileName = System.IO.Path.GetFileName(filePath);
                _uploadFileService.Execute(fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
