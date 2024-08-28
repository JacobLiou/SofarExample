using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfChild
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Process childProcess1;

        private Process childProcess2;

        public MainWindow()
        {
            InitializeComponent();

            if (childProcess1 != null && !childProcess1.HasExited)
            {
                MessageBox.Show("Child process is already running.");
                return;
            }

            childProcess1 = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "WpfChild.exe", // 请确保这个路径是正确的
                    UseShellExecute = true,
                    CreateNoWindow = false
                }
            };

            childProcess1.Start();
            childProcess1.WaitForInputIdle();

            // 获取子进程的主窗口句柄
            IntPtr childHandle = childProcess1.MainWindowHandle;

            // 获取WPF窗口的句柄
            IntPtr hostHandle = new WindowInteropHelper(this).Handle;

            // 将子进程窗口设置为WPF窗口的子窗口
            SetParent(childHandle, hostHandle);

            // 修改子窗口的样式
            SetWindowLong(childHandle, GWL_STYLE, (IntPtr)(WS_VISIBLE | WS_CHILD));

            // 调整子窗口的大小和位置
           
            MoveWindow(childHandle, 10, 50, (int)b1.ActualWidth, (int)b1.ActualHeight, true);
        }

        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll")]
        static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        private const int GWL_STYLE = -16;
        private const int WS_VISIBLE = 0x10000000;
        private const int WS_CHILD = 0x40000000;
    }
}