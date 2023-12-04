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
        public Database StoredUsersDB { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            StoredUsersDB = new Database();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string lastName = tboxLastName.Text;
            string firstName = tboxFirstName.Text;

            if (lastName == "" || firstName == "")
            {
                MessageBox.Show("Le prénom ou nom de famille ne peut être vide!");
                return;
            }
            
            MonthSubscriptions.eSubscriptions subscription = MonthSubscriptions.eSubscriptions.SingleYear;
            if (rdbNetflux1Month.IsChecked == true)
                subscription = MonthSubscriptions.eSubscriptions.SingleMonth;
            else if (rdbNetflux6Month.IsChecked == true)
                subscription = MonthSubscriptions.eSubscriptions.SixMonths;
            else if (rdbNetflux1Year.IsChecked == true)
                subscription = MonthSubscriptions.eSubscriptions.SingleYear;

            bool newsletter = false;
            if (chkbNewsletter.IsChecked == true)
                newsletter = true;

            User user = new User(lastName, firstName, subscription, newsletter);
            StoredUsersDB.DB.Add(user);
        }

        private void btnDisplayDB_Click(object sender, RoutedEventArgs e)
        {
            string displayedText = StoredUsersDB.GetStringRepresentation();
            lblDisplayedDB.Content = displayedText;
        }
    }
}
