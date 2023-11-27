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

namespace Debut_WPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int ButtonCount { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            ButtonCount = 0;
        }

        private void PlusButton_Click(object sender, RoutedEventArgs e)
        {
            ButtonCount++;
        }

        private void MineButton_Click(object sender, RoutedEventArgs e)
        {
            ButtonCount--;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Voici la valeur de ButtonCount: " + ButtonCount, "MainWindow", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
