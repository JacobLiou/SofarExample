using Plugger.Contracts;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RegularCalculator.View
{
    /// <summary>
    /// Interaction logic for RegularView.xaml
    /// </summary>
    public partial class RegularView : UserControl, IPlugger
    {
        public RegularView()
        {
            InitializeComponent();
        }
       
        /// <summary>
        /// This is name will display in main plug board
        /// </summary>
        public string PluggerName { get; set; } = "Regular";

        /// <summary>
        /// This will get called when user clicked on Regular option from plug board
        /// </summary>
        /// <returns></returns>
        public UserControl GetPlugger() => this;

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            lblRes.Content = int.Parse(txtA.Text) + int.Parse(txtB.Text);
        }

        private void BtnSubstract_Click(object sender, RoutedEventArgs e)
        {
            lblRes.Content = int.Parse(txtA.Text) - int.Parse(txtB.Text);
        }

        private void BtnMultiply_Click(object sender, RoutedEventArgs e)
        {
            lblRes.Content = int.Parse(txtA.Text) * int.Parse(txtB.Text);
        }

        private void BtnDivide_Click(object sender, RoutedEventArgs e)
        {
            lblRes.Content = int.Parse(txtA.Text) / int.Parse(txtB.Text);
        }

        private void AllowOnlyNumbers(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
