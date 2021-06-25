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
using System.Windows.Shapes;

namespace Day11TodoEFAli
{
    /// <summary>
    /// Interaction logic for AddEditDialog.xaml
    /// </summary>
    public partial class AddEditDialog : Window
    {
        public Todo currTodo; // null if adding, non-null if editing
        public AddEditDialog(Todo todo = null)
        {
            InitializeComponent();
            comboStatus.ItemsSource = Enum.GetValues(typeof(Todo.StatusEnum)).Cast<Todo.StatusEnum>();
            comboStatus.SelectedIndex = 0;
            dpDueDate.SelectedDate = DateTime.Today;
            if (todo != null)
            {
                currTodo = todo; // save todo being edited
                tbTask.Text = todo.Task;
                dpDueDate.SelectedDate = todo.DueDate;
                comboStatus.SelectedValue = todo.Status;
                btAddEdit.Content = "Update Todo";
            }
            else
            {
                btAddEdit.Content = "Add Todo";
            }
        }

        private void btAddEdit_Click(object sender, RoutedEventArgs e)
        {
            string task = tbTask.Text;
            // Regex re = new Regex();
            if (!Regex.IsMatch(task, @"^[a-zA-Z\d %_\(\),\.\/\\-]{1,200}$"))
            {
                MessageBox.Show(this, "Task must be 1-200 characters, made up of letters, digits, space, %_-(),./\\.", "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DateTime DueDate = dpDueDate.SelectedDate.Value;
            if (DueDate == null)
            {
                MessageBox.Show(this, "Please select due date", "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            DialogResult = true; // assign result and dissmiss dialog
        }
    }
}
