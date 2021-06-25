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

namespace Day06ScoopSelectorAli
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btAddFlavour_Click(object sender, RoutedEventArgs e)
        {
            var selItems = lvFlavours.SelectedItems;
            if (selItems.Count == 0)
            {
                MessageBox.Show(this, "You must select at least one flavour to add", "Input error", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            foreach (ListViewItem item in selItems)
            {
                lvSelected.Items.Add(item.Content); // add a string
            }
            lvFlavours.UnselectAll();
        }

        private void btDeleteAll_Click(object sender, RoutedEventArgs e)
        {
            // ask confirmation before deleting all - use MessageBox
            if (MessageBox.Show(this, "Are you sure you want to delete all scoops in this order?",
                    "Confirmation", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                lvSelected.Items.Clear();
            }
        }

        private void btPlaceOrder_Click(object sender, RoutedEventArgs e)
        {
            // Append information to a file
        }

        private void btDeleteSelectedScoops_Click(object sender, RoutedEventArgs e)
        {
            var selItems = lvSelected.SelectedItems; // collection of string
            if (selItems.Count == 0)
            {
                MessageBox.Show(this, "You must select at least one flavour to delete", "Input error", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            // foreach loop can't modify the collection it is iterating over
            // we must first copy items into a list or array
            string[] selArray = selItems.Cast<string>().ToArray();
            foreach (string item in selArray)
            {
                lvSelected.Items.Remove(item);
            }
        }
    }
}
