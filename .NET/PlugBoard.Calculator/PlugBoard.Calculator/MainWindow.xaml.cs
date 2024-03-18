using Plugger.Contracts;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PlugBoard.Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadView();
        }

        /// <summary>
        /// Load all IPlggers available in PlugBoard Folder
        /// </summary>
        public void LoadView()
        {
            try
            {
                //Configure path of PlugBoard folder to access all calculate libraries 
                string plugName = ConfigurationSettings.AppSettings["Plugs"].ToString();
                TabItem buttonA = new TabItem();
                buttonA.Header = "Welcome";
                buttonA.Height = 30;
                buttonA.Content = "You welcome :)";
                tabPlugs.Items.Add(buttonA);

                var connectors = Directory.GetDirectories(plugName);
                foreach (var connect in connectors)
                {
                    string dllPath = GetPluggerDll(connect);
                    Assembly _Assembly = Assembly.LoadFile(dllPath);
                    var types = _Assembly.GetTypes()?.ToList();
                    var type = types?.Find(a => typeof(IPlugger).IsAssignableFrom(a));
                    var win = (IPlugger)Activator.CreateInstance(type);
                    TabItem button = new TabItem
                    {
                        Header = win.PluggerName,
                        Height = 30,
                        Content = win.GetPlugger()
                    };
                    tabPlugs.Items.Add(button);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Internal Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private string GetPluggerDll(string connect)
        {
            var files = Directory.GetFiles(connect, "*.dll");
            foreach (var file in files)
            {
                if (FileVersionInfo.GetVersionInfo(file).ProductName.StartsWith("Calci"))
                    return file;
            }
            return string.Empty;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
