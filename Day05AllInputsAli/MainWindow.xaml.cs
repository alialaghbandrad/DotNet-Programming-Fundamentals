using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

namespace Day05AllInputsAli
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string name = tbName.Text;
            if (name == "")
            {
                MessageBox.Show(this, "Name must not be empty", "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            // TODO: var checkedButton = gridMain.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            string age = "";
            if (rbAgeBelow18.IsChecked == true)
            {
                age = "Below 18";
            }
            else if (rbAge18to35.IsChecked == true)
            {
                age = "18 to 35";
            }
            else if (rbAge36plus.IsChecked == true)
            {
                age = "36 or above";
            }
            else
            { // internal error
                MessageBox.Show(this, "Error reading radio buttons state", "Internal error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //
            List<string> petsList = new List<string>();
            if (cbPetsCats.IsChecked == true)
            {
                petsList.Add("Cats");
            }
            if (cbPetsDogs.IsChecked == true)
            {
                petsList.Add("Dogs");
            }
            if (cbPetsOther.IsChecked == true)
            {
                petsList.Add("Other");
            }
            string pets = string.Join<string>(",", petsList);
            //
            // alternative: string continent = comboContinent.Text;
            string continent = comboContinent.SelectedValue?.ToString(); // conditional call
            if (continent == null)
            {
                MessageBox.Show(this, "Please select a continent", "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            double tempC = sliderTempC.Value;
            //
            string line = $"{name};{age};{pets};{continent};{tempC}";
            File.AppendAllText(@"..\..\output.txt", line + "\n");
            MessageBox.Show(this, "Data appended to file", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
