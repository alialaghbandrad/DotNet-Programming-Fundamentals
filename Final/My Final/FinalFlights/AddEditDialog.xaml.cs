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

namespace Day09TodoWithDialog
{
    /// <summary>
    /// Interaction logic for AddEditDialog.xaml
    /// </summary>
    public partial class AddEditDialog : Window
    {
        public Todo currTodo; // null if adding, non-null if editing

        public AddEditDialog(Todo td = null)
        {
            InitializeComponent();
            comboStatus.ItemsSource = Enum.GetValues(typeof(Todo.Status)).Cast<Todo.Status>();
            comboStatus.SelectedIndex = 0;
            dpDueDate.SelectedDate = DateTime.Today;
            if (td != null)
            {
                currTodo = td; // save todo being edited
                tbTask.Text = td.Task;
                slDifficulty.Value = td.Difficulty;
                dpDueDate.SelectedDate = td.DueDate;
                comboStatus.Text = td.TaskStatus.ToString();
                btAction.Content = "Update Todo";
            }
            else
            {
                btAction.Content = "Add Todo";
            }
        }

        private void btAction_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string task = tbTask.Text;
                int difficulty = (int)slDifficulty.Value;
                DateTime dueDate = (DateTime)dpDueDate.SelectedDate;
                Todo.Status status = (Todo.Status)Enum.Parse(typeof(Todo.Status), comboStatus.Text, true);
                if (currTodo == null)
                {
                    currTodo = new Todo(task, difficulty, dueDate, status); // ex ArgumentNullException , ArgumentException, OverflowException
                }
                else
                { // ex ArgumentNullException , ArgumentException, OverflowException
                    currTodo.Task = task;
                    currTodo.Difficulty = difficulty;
                    currTodo.DueDate = dueDate;
                    currTodo.TaskStatus = status;
                }
                DialogResult = true; // only dismiss the dialog if there were no exceptions
            }
            catch (Exception ex) when (ex is ArgumentNullException || ex is ArgumentException || ex is OverflowException || ex is InvalidInputException)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

    }
}
