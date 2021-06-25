using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace FinalFlights
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal ObservableCollection<Filght> listFlight = new ObservableCollection<Filght>();
        internal int selectedIndex = 0;
        const string Path = @"..\..\flights.txt";
        public MainWindow()
        {
            InitializeComponent();
            lvFlights.ItemsSource = listFlight;
            LoadDataFromFile();
        }

        private void LoadDataFromFile()
        {
            try
            {
                using (StreamReader sr = File.OpenText(Path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        try
                        {
                            Filght td = new Filght(s);
                            listFlight.Add(td);
                        }
                        catch (InvalidInputException ex)
                        {
                            MessageBox.Show(ex.Message, "Error messsage");
                        }
                    }
                }

            }
            catch (Exception ex) when (ex is IOException || ex is SystemException)
            {
                MessageBox.Show("Error loading from file", "Error messsage");
            }
        }

        private void SaveDataToFile(string path, IList list = null)
        {
            try
            {
                if (list is null)
                {
                    list = listFlight;
                }

                List<string> str = new List<string>();

                // Save document
                foreach (Filght tp in list)
                {
                    str.Add(tp.ToDataString());
                }
                File.WriteAllLines(path, str);
            }
            catch (Exception ex) when (ex is IOException || ex is SystemException)
            {
                MessageBox.Show("Writing to file error", "Error Message");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // See if the user really wants to shut down this window.
            string msg = "Do you want to leave?";
            MessageBoxResult result = MessageBox.Show(msg, "My App", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.No)
            {
                // If user doesn't want to close, cancel closure.
                e.Cancel = true;
            }
            else
            {
                SaveDataToFile(Path);
            }
            // Close();
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveSelectedFlights(object sender, RoutedEventArgs e)
        {
            if (lvFlights.SelectedItems.Count > 0)
            {
                var selItems = lvFlights.SelectedItems;

                // Configure save file dialog box
                SaveFileDialog dlg = new SaveFileDialog { Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*" }; // Filter files by extension

                
                dlg.DefaultExt = ".txt"; // Default file extension

                // Process save file dialog box results
                if (dlg.ShowDialog() == true)
                {
                    SaveDataToFile(dlg.FileName, selItems);
                    lblStatus.Content = "Selected Flight is saved";
                    lvFlights.UnselectAll();
                }
            }
            else
            {
                MessageBox.Show("Nothing is selected", "Warning:");
            }

        }

        private void AddFlightClick(object sender, RoutedEventArgs e)
        {
            AddEditDialog dlg = new AddEditDialog();
            dlg.Owner = this;
            if (dlg.ShowDialog() == true) // confirmed
            {
                listFlight.Add(dlg.currTodo); // add flight that was created in the dialog
                lblStatus.Content = "New Flight added";
            }
        }

        private void UpdateFlightClick(object sender, RoutedEventArgs e)
        {
            if (lvFlights.SelectedItems.Count == 0) return;
            Filght td = (Filght)lvFlights.SelectedItem;
            AddEditDialog dlg = new AddEditDialog(td);
            dlg.Owner = this;
            if (dlg.ShowDialog() == true) // confirmed
            {
                lblStatus.Content = "New Flight added";
                lvFlights.UnselectAll();
                lvFlights.Items.Refresh();
            }
        }

        private void DeleteFlightClick(object sender, RoutedEventArgs e)
        {
            if (lvFlights.SelectedItems.Count == 0) return;
            Filght td = (Filght)lvFlights.SelectedItem;
            selectedIndex = lvFlights.SelectedIndex;

            // See if the user really wants to delete a Flight
            string msg = "Do you want to delete the flight?\n" + td.ToString();
            MessageBoxResult result = MessageBox.Show(msg, "My App", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                listFlight.RemoveAt(selectedIndex);
                lblStatus.Content = "Selected Flight is deleted.";
            }
        }
    }
}
