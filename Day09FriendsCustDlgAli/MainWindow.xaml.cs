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

namespace Day09FriendsCustDlgAli
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> friendsList = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            lvFriends.ItemsSource = friendsList;
        }

        private void miEditAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEditDialog dlg = new AddEditDialog();
            dlg.Owner = this;
            if (dlg.ShowDialog() == true)
            {
                // string name = dlg.NameResult;
                string name = dlg.tbName.Text;
                friendsList.Add(name);
                lvFriends.Items.Refresh();
            }
        }

        private void lvFriends_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string item = (string)lvFriends.SelectedItem; // possible multiple selection
            if (item == null) return;
            AddEditDialog dlg = new AddEditDialog(item);
            dlg.Owner = this;
            if (dlg.ShowDialog() == true)
            {
                int index = friendsList.IndexOf(item);
                friendsList[index] = dlg.tbName.Text;
                lvFriends.Items.Refresh();
            }
        }
    }
}
