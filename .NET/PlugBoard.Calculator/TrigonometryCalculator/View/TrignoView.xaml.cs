using Plugger.Contracts;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TrigonometryCalculator.View
{
    /// <summary>
    /// Interaction logic for TrignoView.xaml
    /// </summary>
    public partial class TrignoView : UserControl, IPlugger
    {
        public TrignoView()
        {
            InitializeComponent();
        }

        private void BtnSin_Click(object sender, RoutedEventArgs e)
        {
            var value = double.Parse(txtA.Text);
            lblRes.Content = Math.Sin(value);
        }

        private void BtnCos_Click(object sender, RoutedEventArgs e)
        {
            var value = double.Parse(txtA.Text);
            lblRes.Content = Math.Cos(value);
        }

        private void BtnTan_Click(object sender, RoutedEventArgs e)
        {
            var value = double.Parse(txtA.Text);
            lblRes.Content = Math.Tan(value);
        }

        private void AllowOnlyNumbers(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public string PluggerName { get; set; } = "Trigonometry";

        public UserControl GetPlugger() => this;
    }
}
