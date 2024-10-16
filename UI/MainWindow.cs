using Gtk;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DropUp.UI
{
    public class MainWindow : Window
    {
        private readonly UploadFileService _uploadFileService;
        private readonly Button _uploadButton;
        private readonly Label _statusLabel;
        private readonly Label _title;

        public MainWindow(UploadFileService uploadFileService) : base("DropUp")
        {
            _uploadFileService = uploadFileService;

            SetDefaultSize(400, 200);
            DeleteEvent += (o, e) => Application.Quit();

            _uploadButton = new Button("Upload File");
            _uploadButton.Clicked += async (sender, e) => await OnUploadButtonClicked();

            _statusLabel = new Label("Selected File to Upload");
            _title = new Label("Welcome to DropUp!");

            var vbox = new VBox(false, 20);
            vbox.PackStart(_title, false, false, 0);
            vbox.PackStart(_uploadButton, false, false, 20);
            vbox.PackStart(_statusLabel, false, false, 0);

            Add(vbox);
            ShowAll();
        }

        private async Task OnUploadButtonClicked()
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
                fileChooser.Destroy();

                await UploadFile(filePath);
            }
            else
            {
                fileChooser.Destroy();
                UpdateStatus("No file found", isError: true);
            }
        }

        private async Task UploadFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                UpdateStatus($"No file found: {filePath}", isError: true);
                return;
            }

            try
            {
                _uploadButton.Sensitive = false;
                UpdateStatus("Uploading...");

                string downloadLink = await _uploadFileService.Execute(filePath);

                var clipboard = Clipboard.Get(Gdk.Atom.Intern("CLIPBOARD", false));
                clipboard.Text = downloadLink;

                UpdateStatus("Uploaded successfully! The link is available at your clipboard.");
            }
            catch (Exception ex)
            {
                UpdateStatus($"Error: {ex.Message}", isError: true);
            }
            finally
            {
                _uploadButton.Sensitive = true;
            }
        }

        private void UpdateStatus(string message, bool isError = false)
        {
            _statusLabel.Text = message;
            _statusLabel.ModifyFg(StateType.Normal, isError ? new Gdk.Color(255, 0, 0) : new Gdk.Color(255, 255, 255));
        }
    }
}
