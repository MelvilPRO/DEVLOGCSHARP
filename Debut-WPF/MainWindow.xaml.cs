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
        HitPoints HPs {  get; set; }
        public MainWindow()
        {
            InitializeComponent();
            HPs = new HitPoints();

            DataContext = this;
        }

        private void Taper1_Click(object sender, RoutedEventArgs e)
        {
            HPs.HP = "" + (int.Parse(HPs.HP) - 1);
        }

        private void Taper2_Click(object sender, RoutedEventArgs e)
        {
            HPs.HP = "" + (int.Parse(HPs.HP) + 1);
        }
    }
}
