using MvvmDialogs;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace MvvmDialogsDemo
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        private readonly IDialogService dialogService;

        public UserControlViewModel UserControlVM { get; set; }

        public List<string> Texts { get; set; } = new();

        public UserControl1()
        {
            InitializeComponent();
            dialogService = new DialogService();
            UserControlVM = new UserControlViewModel();
            this.DataContext = UserControlVM;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialogViewModel = new AddTextDialogViewModel();
            dialogViewModel.Text = "Now";
            bool? success = dialogService.ShowDialog(UserControlVM, dialogViewModel);
            if (success == true)
            {
                Texts.Add(dialogViewModel.Text);
            }
        }

        
    }

    public class UserControlViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
    }

    public class AddTextDialogViewModel : IModalDialogViewModel
    {
        public string Text { get; set; }

        public bool? DialogResult => string.IsNullOrEmpty(Text) ? false : true;

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
