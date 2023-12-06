using System;
using System.IO;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonLireCSV_Click(object sender, RoutedEventArgs e)
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "\\ScoresGOT.csv";
            string readText = "";
            try
            {
                readText = File.ReadAllText(filePath);
            }
            catch 
            {
                MessageBox.Show("Le fichier n'a pas pu être ouvert, il est non existant ou en cours d'utilisation!", "MainWindow",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (readText == "")
            {
                MessageBox.Show("Le fichier est vide!", "MainWindow", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string[] splitLines = readText.Split('\n');


            List<int> filteredSuccessRates = new List<int>();
            List<int> filteredScores = new List<int>();

            for (int lineIndex = 0; lineIndex < splitLines.Length - 1; lineIndex++)
            {
                // Eviter les noms des colonnes en première ligne
                if (lineIndex == 0)
                    continue;

                string currentLine = splitLines[lineIndex];
                string[] splitLine = currentLine.Split(';');

                int currentSuccessRate = int.Parse(splitLine[2]);
                if (currentSuccessRate == 0)
                    continue;

                int currentScore = int.Parse(splitLine[3]);
                if (currentScore == 0)
                    continue;

                filteredSuccessRates.Add(currentSuccessRate);
                filteredScores.Add(currentScore);
            }

            float moyenneSuccessRates = 0;
            foreach (int successRate in filteredSuccessRates)
                moyenneSuccessRates += successRate;
            moyenneSuccessRates = moyenneSuccessRates / filteredSuccessRates.Count;

            float moyenneScores = 0;
            foreach (int score in filteredScores)
                moyenneScores += score;
            moyenneScores = moyenneScores / filteredScores.Count;

            TBlockDisplayMoyenne.Text = ("Moyenne des success rates: " + moyenneSuccessRates + "\n"
                                       + "Moyenne des scores: " + moyenneScores);
        }
    }
}
