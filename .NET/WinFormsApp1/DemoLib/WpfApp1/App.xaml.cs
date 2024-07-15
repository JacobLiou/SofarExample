using System.Configuration;
using System.Data;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //阻塞附加调试
            MessageBox.Show("sdfdsfds");

            // 检查是否有命令行参数（拖放的文件）
            if (e.Args.Length > 0)
            {
                // 获取拖放的文件路径
                string[] filePaths = e.Args;

                // 打开主窗口并传递文件路径
                MainWindow mainWindow = new MainWindow(filePaths);
                mainWindow.Show();
            }
            else
            {
                // 正常启动，没有拖放文件
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
        }
    }

}
