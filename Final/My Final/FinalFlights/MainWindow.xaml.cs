using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace Day09TodoWithDialog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal ObservableCollection<Todo> listTodo = new ObservableCollection<Todo>();
        internal int selectedIndex = 0;
        const string Path = @"..\..\todos.txt";
        public MainWindow()
        {
            InitializeComponent();
            lvTodos.ItemsSource = listTodo;
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
                            Todo td = new Todo(s);
                            listTodo.Add(td);
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
                    list = listTodo;
                }

                List<string> str = new List<string>();

                // Save document
                foreach (Todo tp in list)
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

        private void SaveSelectedTodos(object sender, RoutedEventArgs e)
        {
            if (lvTodos.SelectedItems.Count > 0)
            {
                var selItems = lvTodos.SelectedItems;

                // Configure save file dialog box
                SaveFileDialog dlg = new SaveFileDialog { Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*" }; // Filter files by extension

                //dlg.FileName = "todo"; // Default file name
                dlg.DefaultExt = ".txt"; // Default file extension

                // Process save file dialog box results
                if (dlg.ShowDialog() == true)
                {
                    SaveDataToFile(dlg.FileName, selItems);
                    lblStatus.Content = "Selected Todo is saved";
                    lvTodos.UnselectAll();
                }
            }
            else
            {
                MessageBox.Show("Nothing is selected", "Warning:");
            }

        }

        private void AddTodoClick(object sender, RoutedEventArgs e)
        {
            AddEditDialog dlg = new AddEditDialog();
            dlg.Owner = this;
            if (dlg.ShowDialog() == true) // confirmed
            {
                listTodo.Add(dlg.currTodo); // add todo that was created in the dialog
                lblStatus.Content = "New Todo added";
            }
        }

        private void UpdateTodoClick(object sender, RoutedEventArgs e)
        {
            if (lvTodos.SelectedItems.Count == 0) return;
            Todo td = (Todo)lvTodos.SelectedItem;
            AddEditDialog dlg = new AddEditDialog(td);
            dlg.Owner = this;
            if (dlg.ShowDialog() == true) // confirmed
            {
                lblStatus.Content = "New Todo added";
                lvTodos.UnselectAll();
                lvTodos.Items.Refresh();
            }
        }

        private void DeleteTodoClick(object sender, RoutedEventArgs e)
        {
            if (lvTodos.SelectedItems.Count == 0) return;
            Todo td = (Todo)lvTodos.SelectedItem;
            selectedIndex = lvTodos.SelectedIndex;

            // See if the user really wants to delete a Todo
            string msg = "Do you want to delete the todo?\n" + td.ToString();
            MessageBoxResult result = MessageBox.Show(msg, "My App", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                listTodo.RemoveAt(selectedIndex);
                lblStatus.Content = "Selected Todo is deleted.";
            }
        }

    }
}
