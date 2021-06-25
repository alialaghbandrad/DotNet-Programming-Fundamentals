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

namespace FinalFlights
{
    /// <summary>
    /// Interaction logic for AddEditDialog.xaml
    /// </summary>
    public partial class AddEditDialog : Window
    {

        public Filght currTodo; // null if adding, non-null if editing

        public AddEditDialog(Filght td = null)
        {
            InitializeComponent();
            comboType.ItemsSource = Enum.GetValues(typeof(Filght.Type)).Cast<Filght.Type>();
            comboType.SelectedIndex = 0;
            dpDueDate.SelectedDate = DateTime.Today;
            if (td != null)
            {
                currTodo = td; // save todo being edited
                tbFromCode.Text = td.FromCode;
                tbToCode.Text = td.ToCode;
                slPassengers.Value = td.Passengers;
                dpDueDate.SelectedDate = td.DueDate;
                comboType.Text = td.TypeStatus.ToString();
                btAction.Content = "Update Flight";
            }
            else
            {
                btAction.Content = "Add Flight";
            }
        }

        private void btAction_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string fromCode = tbFromCode.Text;
                string toCode = tbToCode.Text;
                int passengers = (int)slPassengers.Value;
                DateTime dueDate = (DateTime)dpDueDate.SelectedDate;
                Filght.Type type = (Filght.Type)Enum.Parse(typeof(Filght.Type), comboType.Text, true);
                if (currTodo == null)
                {
                    currTodo = new Filght(dueDate, fromCode, toCode, type, passengers); // ex ArgumentNullException , ArgumentException, OverflowException
                }
                else
                { // ex ArgumentNullException , ArgumentException, OverflowException
                    currTodo.FromCode = fromCode;
                    currTodo.ToCode = toCode;
                    currTodo.Passengers = passengers;
                    currTodo.DueDate = dueDate;
                    currTodo.TypeStatus = type;
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
