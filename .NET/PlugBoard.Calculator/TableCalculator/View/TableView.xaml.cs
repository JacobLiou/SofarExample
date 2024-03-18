using Plugger.Contracts;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TableCalculator.View
{
    /// <summary>
    /// Interaction logic for TableView.xaml
    /// </summary>
    public partial class TableView : UserControl, IPlugger
    {
        public TableView()
        {
            InitializeComponent();
        }

        private void BtnTable_Click(object sender, RoutedEventArgs e)
        {
            lblRes.Content = string.Empty;
            int num = int.Parse(txtA.Text);
            for (int i = 1; i <= 10; i++)
                lblRes.Content += (num * i).ToString() + ", ";

            lblRes.Content = lblRes.Content.ToString().TrimEnd(',', ' ');
        }

        private void AllowOnlyNumbers(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public string PluggerName { get; set; } = "Table Calci";

        public UserControl GetPlugger() => this;
    }
}
