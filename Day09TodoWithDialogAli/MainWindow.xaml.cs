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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Day09TodoWithDialogAli
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Task> tasksList = new List<Task>();

        public MainWindow()
        {
            InitializeComponent();
            lvTaskList.ItemsSource = tasksList;
        }

        private void miEditAdd_Click(object sender, RoutedEventArgs e)
        {
            
            AddEditDialog dlg = new AddEditDialog();
            dlg.Owner = this;
            if (dlg.ShowDialog() == true)
            {
                string desc = dlg.tbTask.Text;
                double diff = dlg.tbDiff.Value;
                
                if (dlg.dpDeparture.SelectedDate == null)
                {
                    MessageBox.Show(this, "Please select due date", "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                
                DateTime departureDate = dlg.dpDeparture.SelectedDate.Value;
                string status = dlg.comboStatus.Text;
                Task task = new Task(desc, diff, departureDate, status); // ex InvalidDataExceptio
                tasksList.Add(task);
                lvTaskList.Items.Refresh();
            
                
            }

        }


    }
}


           
            