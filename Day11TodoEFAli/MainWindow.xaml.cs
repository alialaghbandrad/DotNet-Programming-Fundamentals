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

namespace Day11TodoEFAli
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TodosDBContext ctx;
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                ctx = new TodosDBContext();
                lvToDoList.ItemsSource = (from t in ctx.Todos select t).ToList<Todo>();
            }
            catch (SystemException ex) // catch-all for EF, SQL and many other exceptions
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("Fatal error: Database connection failed:\n" + ex.Message);
                Environment.Exit(1); // fatal error
            }
        } 

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Do you want to leave?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void miExportSelected_Click(object sender, RoutedEventArgs e)
        {

        }

        private void miDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteTodo();
        }

        private void miExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void lvToDoList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Todo todo = (Todo)lvToDoList.SelectedItem;
            if (todo == null)
            {
                return;
            }
            AddEditDialog dlg = new AddEditDialog(todo);
            dlg.Owner = this;
            if (dlg.ShowDialog() == true)
            {
                todo.Task = dlg.tbTask.Text;
                todo.DueDate = (DateTime)dlg.dpDueDate.SelectedDate;
                todo.Status = (Todo.StatusEnum)dlg.comboStatus.SelectedItem;
                // ctx.Todos.Add(todo);
                ctx.SaveChanges();
                lvToDoList.ItemsSource = (from t in ctx.Todos select t).ToList<Todo>();
            }
        }

        private void miRightclickDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteTodo();
        }

        private void miAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEditDialog dlg = new AddEditDialog();
            dlg.Owner = this;
            
            if (dlg.ShowDialog() == true)
            {
                try
                { 
                    string task = dlg.tbTask.Text;
                    DateTime dueDate = dlg.dpDueDate.SelectedDate.Value;
                    if (dlg.dpDueDate.SelectedDate == null)
                    {
                        MessageBox.Show(this, "Please select due date", "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    Todo.StatusEnum status = (Todo.StatusEnum)dlg.comboStatus.SelectedItem;

                    Todo todo = new Todo { Task = task, DueDate = dueDate, Status = status };
                    ctx.Todos.Add(todo);
                    ctx.SaveChanges();
                    lvToDoList.ItemsSource = (from t in ctx.Todos select t).ToList<Todo>();

                    Console.WriteLine("Todo added.");

                } catch (SystemException ex)  // catch-all for EF, SQL and many other exceptions
                {
                    Console.WriteLine(ex.StackTrace);
                    MessageBox.Show("Database operation failed:\n" + ex.Message);
                }
                    
            }
        }

        public void DeleteTodo()
        {
            if (lvToDoList.SelectedValue == null) // (lvToDoList.SelectedIndex == -1)
            {
                MessageBox.Show(this, "Please select an item to delete", "Selection error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Todo selTodo = (Todo)lvToDoList.SelectedItem;
            MessageBoxResult result = MessageBox.Show("Do you want to delete: " + selTodo.ToString() + " ?", "Data save", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                ctx.Todos.Remove(selTodo);
                ctx.SaveChanges();
                lvToDoList.ItemsSource = (from t in ctx.Todos select t).ToList<Todo>();
            }
        }
    }
}
