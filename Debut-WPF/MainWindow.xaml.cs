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
        public int Calculation { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Calculation = 0;
        }

        private void ApplyGraphicalCount()
        {
            LabelCount.Content = "" + Calculation;
        }

        private void TryCalculateUserEntries(OperationType operationType)
        {
            int receivedInt1, receivedInt2;
            if (int.TryParse(UserEntry1.Text, out receivedInt1) == false)
            {
                MessageBox.Show("Le texte d'entrée n°1 n'est pas un entier");
                return;
            }
            if (int.TryParse(UserEntry2.Text, out receivedInt2) == false)
            {
                MessageBox.Show("Le texte d'entrée n°2 n'est pas un entier");
                return;
            }

            switch (operationType)
            {
            case OperationType.Addition:
                Calculation = receivedInt1 + receivedInt2;
                break;

            case OperationType.Substract:
                Calculation = receivedInt1 - receivedInt2;
                break;

            case OperationType.Multiply:
                Calculation = receivedInt1 * receivedInt2;
                break;

            case OperationType.Divide:
                Calculation = receivedInt1 / receivedInt2;
                break;

            default:
                MessageBox.Show("Le type d'operation n'est pas reconnu!");
                break;
            }

            ApplyGraphicalCount();
        }

        private void PlusButton_Click(object sender, RoutedEventArgs e)
        {
            TryCalculateUserEntries(OperationType.Addition);
        }

        private void MineButton_Click(object sender, RoutedEventArgs e)
        {
            TryCalculateUserEntries(OperationType.Substract);
        }

        private void MultButton_Click(object sender, RoutedEventArgs e)
        {
            TryCalculateUserEntries(OperationType.Multiply);
        }

        private void DiviButton_Click(object sender, RoutedEventArgs e)
        {
            TryCalculateUserEntries(OperationType.Divide);
        }
    }
}
