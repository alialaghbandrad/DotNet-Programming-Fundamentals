using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Day05MultiTempConvAli
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            recalulate();
        }

        private void tbInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            recalulate();
        }

        private void AnyRadioButton_Click(object sender, RoutedEventArgs e)
        {
            recalulate();
        }


        private void recalulate()
        {
            // do nothing if the whole XAML hasn't loaded yet
            if (rbOutKel == null) return;
            // 1. parse the input
            if (!double.TryParse(tbInput.Text, out double inVal))
            {
                tbOutput.Text = "Error";
                return;
            }
            // 2. convert to celsius
            double cel;
            if (rbInCel.IsChecked == true)
            {
                cel = inVal;
            }
            else if (rbInFah.IsChecked == true)
            {
                cel = (inVal - 32) * 5 / 9;
            }
            else if (rbInKel.IsChecked == true)
            {
                cel = inVal - 273.15;
            }
            else
            { // should never happen
                MessageBox.Show(this, "Invalid control flow", "Internal error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            // 3. convert to the output unit
            double outVal;
            String unit;
            if (rbOutCel.IsChecked == true)
            {
                outVal = cel;
                unit = "C";
            }
            else if (rbOutFah.IsChecked == true)
            {
                outVal = cel * 9 / 5 + 32;
                unit = "F";
            }
            else if (rbOutKel.IsChecked == true)
            {
                outVal = cel + 273.15;
                unit = "K";
            }
            else
            { // should never happen
                MessageBox.Show(this, "Invalid control flow", "Internal error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            // 4. display the result
            tbOutput.Text = $"{outVal:0.0}{unit}";
        }

        private void tbInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // anything that is not a numer, dot, or space is not allowed
            Regex regex = new Regex(@"[^0-9\.]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }

}
