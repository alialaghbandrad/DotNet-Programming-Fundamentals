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

namespace Day06HelloWpfAli
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

        private void SayHelloLabelButton_Click(object sender, RoutedEventArgs e)
        {
            string name = tbName.Text;
            if (name == "")
            {
                MessageBox.Show(this, "Please enter a name", "Input error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            string greeting = $"Hello {name}, nice to meet you";
            lblGreeting.Content = greeting;
        }

        private void SayHelloMessageBoxButton_Click(object sender, RoutedEventArgs e)
        {
            string name = tbName.Text;
            if (name == "")
            {
                MessageBox.Show(this, "Please enter a name", "Input error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            string greeting = $"Hello {name}, nice to meet you";
            MessageBox.Show(this, greeting, "Greeting", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
