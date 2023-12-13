using System;
using System.Collections;
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
using System.Xml;
using System.Xml.Linq;

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

        private void DisplayImageFromUrl(string url)
        {
            try
            {
                BitmapImage bitmap = new BitmapImage();

                bitmap.BeginInit();
                bitmap.UriSource = new Uri(url);
                bitmap.EndInit();

                DisplayedGameImage.Source = bitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement de l'image : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BoardGameGeek_Click(object sender, RoutedEventArgs e)
        {
            // Transformer l'id placé par l'utilisateur, en vérifiant que le champs est valide (c'est un nombre)
            if (BoardGameGeekIdEntry.Text == "")
            {
                MessageBox.Show("Le champ d'entrée ne peut être vide!", "BoardGameGeekAPI", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!int.TryParse(BoardGameGeekIdEntry.Text, out int userNumberId))
            {
                MessageBox.Show("Le champ d'entrée est incorrect, ce n'est pas un nombre valide!", "BoardGameGeekAPI", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string specifiedGameUrl = BoardGameGeekInfos.BoardGameGeekUrl + userNumberId;

            XmlNodeList loadedGameNodes;
            try
            {
                XmlDocument loadedGameXML = new XmlDocument();
                loadedGameXML.Load(specifiedGameUrl);
                loadedGameNodes = loadedGameXML.SelectNodes("//*");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite : " + ex.Message, "BoardGameGeekAPI", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (loadedGameNodes.Count <= 5)
            {
                MessageBox.Show("Le jeu n'a pas l'air présent dans la base de donnée", "BoardGameGeekAPI", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            foreach (XmlNode node in loadedGameNodes)
            {
                if (node.Name == "image" && node.InnerText.StartsWith("http"))
                {
                    DisplayImageFromUrl(node.InnerText);
                }
            }

            XmlNode wholeNode = loadedGameNodes.Item(0);

            DisplayedGameDescription.Text = "";
            List<string> receivedArtists = SearchArtistsRecursively(wholeNode);
            foreach (string receivedArtist in receivedArtists)
            {
                DisplayedGameDescription.Text += receivedArtist + "\n";
            }
        }

        private List<string> SearchArtistsRecursively(XmlNode node)
        {
            List<string> result = new List<string>();

            if (node.Name == "boardgameartist")
            {
                result.Add(node.InnerText);
            }

            foreach (XmlNode childNode in node.ChildNodes)
            {
                List<string> childResult = SearchArtistsRecursively(childNode);
                result.AddRange(childResult);
            }

            return result;
        }
    }
}
