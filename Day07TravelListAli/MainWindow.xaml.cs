using Microsoft.Win32;
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

namespace Day07TravelListAli
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        const string DataFileName = @"..\..\data.txt";

        List<Trip> tripsList = new List<Trip>();

        public MainWindow()
        {
            InitializeComponent();
            LoadDataFromFile();
            lvTripList.ItemsSource = tripsList;
        }

        private void btAddTrip_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get/Set the inputs:
                string destination = tbDestination.Text;
                string name = tbName.Text;
                string passportNo = tbPassportNo.Text;
                if (dpDeparture.SelectedDate == null || dpReturn.SelectedDate == null)
                {
                    MessageBox.Show(this, "Please select both departure and return dates", "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                DateTime departureDate = dpDeparture.SelectedDate.Value;
                DateTime returnDate = dpReturn.SelectedDate.Value;
                //
                Trip trip = new Trip(destination, name, passportNo, departureDate, returnDate); // ex InvalidDataException
                tripsList.Add(trip);
                lvTripList.Items.Refresh(); // inform ListView that data has changed   (version 1)
                // lvTripList.Items.Add(trip);       (version 2)
                // Clear the inputs
                tbDestination.Clear();
                tbName.Clear();
                tbPassportNo.Clear();
                dpDeparture.SelectedDate = null;
                dpReturn.SelectedDate = null;
            } catch (InvalidDataException ex)
            {
                MessageBox.Show(this, ex.Message, "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btSaveSelected_Click(object sender, RoutedEventArgs e)
        {
            var selItems = lvTripList.SelectedItems.Cast<Trip>().ToList();
            if (selItems.Count == 0)
            {
                MessageBox.Show(this, "Please select some items first", "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Pdf files (*.pdf)|*.pdf|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            // saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == true)
            {
                string fileName = saveFileDialog.FileName;
                SaveDataToFile(fileName, selItems);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveDataToFile(DataFileName, tripsList);
        }

        private void SaveDataToFile(string fileName, List<Trip> tripsToSave)
        {
            try
            {
                List<string> linesList = new List<string>();
                foreach (Trip t in tripsToSave)
                {
                    linesList.Add(t.ToDataString());
                }
                File.WriteAllLines(fileName, linesList);
            }
            catch (Exception ex) when (ex is IOException || ex is SystemException)
            {
                MessageBox.Show(this, ex.Message, "File IO error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadDataFromFile()
        {
            try
            {
                if (!File.Exists(DataFileName)) return; // do nothing if the file does not exist yet
                string[] linesList = File.ReadAllLines(DataFileName);
                foreach (string line in linesList)
                {
                    try
                    {
                        Trip trip = new Trip(line); // ex InvalidDataException
                        tripsList.Add(trip);
                    }
                    catch (InvalidDataException ex)
                    {
                        MessageBox.Show(this, "Ignoring invalid line.\n" + ex.Message, "File data error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                File.WriteAllLines(@"..\..\data.csv", linesList);
            }
            catch (Exception ex) when (ex is IOException || ex is SystemException)
            {
                MessageBox.Show(this, ex.Message, "File IO error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void lvTripList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
