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
            // Chemin du fichier dans le même répertoire que l'executable
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

            // Cas d'un fichier présent dans le dossier mais un contenu vide
            if (readText == "")
            {
                MessageBox.Show("Le fichier est vide!", "MainWindow", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Il faut au moins tout les noms des colonnes
            // Mais aussi un enregistrement est nécessaire
            string[] splitLines = readText.Split('\n');
            if (splitLines.Length <= 1)
            {
                MessageBox.Show("Le fichier n'a pas plusieurs lignes!", "MainWindow", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Vérifie si les colonnes pour faire les moyennes ont présentes

            string successRateKey = "successRate";
            string scoreKey = "score\r";

            string[] columnNames = splitLines[0].Split(';');
            if (!(columnNames.Contains(successRateKey) && columnNames.Contains(scoreKey)))
            {
                MessageBox.Show("Le fichier n'a pas la ou les colonnes successRate et score!", "MainWindow", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Index dynamiques si l'emplacement des colonnes changent dans le tableau
            int successRateIndex = Array.IndexOf(columnNames, successRateKey);
            int scoreIndex = Array.IndexOf(columnNames, scoreKey);

            // Nous stockons les success rates et scores lorsqu'ils ne sont pas à 0
            // Nous trouvons ces valeurs avec successRateIndex et scoreIndex
            List<int> filteredSuccessRates = new List<int>();
            List<int> filteredScores = new List<int>();
            
            for (int lineIndex = 1; lineIndex < splitLines.Length - 1; lineIndex++)
            {
                string currentLine = splitLines[lineIndex];
                string[] splitLine = currentLine.Split(';');

                int currentSuccessRate = int.Parse(splitLine[successRateIndex]);
                int currentScore = int.Parse(splitLine[scoreIndex]);

                if (currentSuccessRate == 0 || currentScore == 0)
                    continue;

                filteredSuccessRates.Add(currentSuccessRate);
                filteredScores.Add(currentScore);
            }

            // Calcul des 2 moyennes
            float moyenneSuccessRates = 0;
            foreach (int successRate in filteredSuccessRates)
                moyenneSuccessRates += successRate;
            moyenneSuccessRates = moyenneSuccessRates / filteredSuccessRates.Count;

            float moyenneScores = 0;
            foreach (int score in filteredScores)
                moyenneScores += score;
            moyenneScores = moyenneScores / filteredScores.Count;

            // Affichage a l'ecran
            TBlockDisplayMoyenne.Text = ("Moyenne des success rates: " + moyenneSuccessRates + "\n"
                                       + "Moyenne des scores: " + moyenneScores);
        }
    }
}
