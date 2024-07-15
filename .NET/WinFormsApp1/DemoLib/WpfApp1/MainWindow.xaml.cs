using System.Windows;
using System.Windows.Documents;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(string[] filePaths = null)
        {
            InitializeComponent();

            if (filePaths != null && filePaths.Length > 0)
            {
                OpenFiles(filePaths);
            }
        }

        private void OpenFiles(string[] filePaths)
        {
            rich.Document.Blocks.Clear();
            foreach (string filePath in filePaths)
            {
                //// 在这里实现打开文件的逻辑
                //MessageBox.Show($"Opening file: {filePath}");
                try
                {
                    string text = System.IO.File.ReadAllText(filePath);

                    rich.Document.Blocks.Add(new Paragraph(new Run(text)));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }

    }
}