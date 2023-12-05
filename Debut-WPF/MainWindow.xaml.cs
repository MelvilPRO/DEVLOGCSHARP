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
        private Database DB {  get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DB = new Database();
            DB.InsertFakeMusics();
        }

        private void DisplayGivenDB(Database database)
        {
            TBlockDisplayedDB.Text = database.ToString();
        }

        private void BTNPop_Click(object sender, RoutedEventArgs e)
        {
            Database filtered = new Database(DB.FilterGenre(EMusics.Pop));
            DisplayGivenDB(filtered);   
        }

        private void BTNRap_Click(object sender, RoutedEventArgs e)
        {
            Database filtered = new Database(DB.FilterGenre(EMusics.Rap));
            DisplayGivenDB(filtered);
        }

        private void BTNRock_Click(object sender, RoutedEventArgs e)
        {
            Database filtered = new Database(DB.FilterGenre(EMusics.Rock));
            DisplayGivenDB(filtered);
        }
    }
}
