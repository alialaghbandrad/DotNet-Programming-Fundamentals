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

namespace Day10PeopleEFGUIAli
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PeopleDbContext ctx;

        public MainWindow()
        {
            try
            {
                InitializeComponent();
                ctx = new PeopleDbContext();
                lvPeople.ItemsSource = (from p in ctx.People select p).ToList<Person>();
            }
            catch (SystemException ex) // catch-all for EF, SQL and many other exceptions
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("Fatal error: Database connection failed:\n" + ex.Message);
                Environment.Exit(1); // fatal error
            }
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            string name = tbName.Text;
            if (!int.TryParse(tbAge.Text, out int age))
            {
                MessageBox.Show("Age invalid");
                return;
            }
            try
            {
                Person person = new Person { Name = name, Age = age };
                ctx.People.Add(person);
                ctx.SaveChanges();
                tbName.Text = "";
                tbAge.Text = "0";
                // refresh the list for database
                lvPeople.ItemsSource = (from p in ctx.People select p).ToList<Person>();
            }
            catch (SystemException ex) // catch-all for EF, SQL and many other exceptions
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("Database operation failed:\n" + ex.Message);
            }
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {   // BAD STYLE: Code duplication with add - do NOT do it
            string name = tbName.Text;
            if (!int.TryParse(tbAge.Text, out int age))
            {
                MessageBox.Show("Age invalid");
                return;
            }
            try
            {
                currSelPerson.Name = name;
                currSelPerson.Age = age;
                ctx.SaveChanges();
                tbName.Text = "";
                tbAge.Text = "";
                // refresh the list for database
                lvPeople.ItemsSource = (from p in ctx.People select p).ToList<Person>();
            }
            catch (SystemException ex) // catch-all for EF, SQL and many other exceptions
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("Database operation failed:\n" + ex.Message);
            }

        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            if (currSelPerson == null) return;
            var result = MessageBox.Show(this, "Are you sure you want to delete this record?\n" + currSelPerson, "Confirmation requried", MessageBoxButton.OKCancel, MessageBoxImage.Question, MessageBoxResult.Cancel);
            if (result == MessageBoxResult.OK)
            {
                ctx.People.Remove(currSelPerson); // schedule attached entity for deletion
                ctx.SaveChanges();
                lvPeople.ItemsSource = (from p in ctx.People select p).ToList<Person>();
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)  // Allows only numbers to be entered
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        Person currSelPerson;

        private void lvPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currSelPerson = lvPeople.SelectedItem as Person;
            if (currSelPerson == null)
            {
                btUpdate.IsEnabled = false;
                btDelete.IsEnabled = false;
                lblId.Content = "-";
                tbName.Text = "";
                tbAge.Text = "";
            }
            else
            {
                btUpdate.IsEnabled = true;
                btDelete.IsEnabled = true;
                lblId.Content = currSelPerson.Id;
                tbName.Text = currSelPerson.Name;
                tbAge.Text = currSelPerson.Age + "";
            }
        }
    }
}
