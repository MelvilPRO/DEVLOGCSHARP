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
        public Database StoredUsers { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            StoredUsers = new Database();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string lastName = tboxLastName.Text;
            string firstName = tboxFirstName.Text;
            
            MonthSubscriptions.eSubscriptions subscription = MonthSubscriptions.eSubscriptions.SingleYear;
            if (rdbNetflux1Month.IsChecked == true)
                subscription = MonthSubscriptions.eSubscriptions.SingleMonth;
            if (rdbNetflux6Month.IsChecked == true)
                subscription = MonthSubscriptions.eSubscriptions.SixMonths;
            if (rdbNetflux1Year.IsChecked == true)
                subscription = MonthSubscriptions.eSubscriptions.SingleYear;

            bool newsletter = false;
            if (chkbNewsletter.IsChecked == true)
                newsletter = true;

            User user = new User(lastName, firstName, subscription, newsletter);
            StoredUsers.DB.Add(user);
        }
    }
}
