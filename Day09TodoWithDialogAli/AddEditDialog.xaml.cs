using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Day09TodoWithDialogAli
{
    /// <summary>
    /// Interaction logic for AddEditDialog.xaml
    /// </summary>
    public partial class AddEditDialog : Window
    {
        public AddEditDialog()
        {
            InitializeComponent();
            // lvTaskList.ItemsSource = tasksList;
        }

        private List<Task> tasksList = new List<Task>();

        private void btAddTodo_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                // Get/Set the inputs:
                string desc = tbTask.Text;
                double diff = tbDiff.Value;
                if (dpDeparture.SelectedDate == null)
                {
                    MessageBox.Show(this, "Please select both departure and return dates", "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                DateTime departureDate = dpDeparture.SelectedDate.Value;
                string status = comboStatus.Text;
                Task task = new Task(desc, diff, departureDate, status); // ex InvalidDataExceptio
                tasksList.Add(task);
                // lvTaskList.Items.Refresh();
                tbTask.Clear();
                dpDeparture.SelectedDate = null;

            }
            catch (InvalidDataException ex)
            {
                MessageBox.Show(this, ex.Message, "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
