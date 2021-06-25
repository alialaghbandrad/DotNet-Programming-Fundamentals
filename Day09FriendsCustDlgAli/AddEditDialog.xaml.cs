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

namespace Day09FriendsCustDlgAli
{
    /// <summary>
    /// Interaction logic for AddEditDialog.xaml
    /// </summary>
    public partial class AddEditDialog : Window
    {
        public AddEditDialog()
        {
            InitializeComponent();
            if (name == null)
            { // adding
                btSave.Content = "Add";
            }
            else
            { // editing
                btSave.Content = "Update";
                tbName.Text = name;
            }
        }

        /*
        private string _nameResult;
        public string NameResult // read-only property
        {
            get { return _nameResult; }
        } */

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            string name = tbName.Text;
            if (name.Length < 2 || name.Length > 20)
            {
                MessageBox.Show(this, "Name must be 2-20 characters long", "Input error", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            // _nameResult = name;
            DialogResult = true; // assing result and dismiss the dialog
        }
    }
}
