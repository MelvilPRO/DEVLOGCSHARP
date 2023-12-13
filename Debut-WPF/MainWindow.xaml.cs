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
        static public int DisplayedUsersMax = 5;
        public int MinPrix { get; set; }
        public int MaxPrix { get; set; }
        public int CurPrix { get; set; }
        public int Tentatives { get; set; }
        public User CurrentUser { get; set; }
        public Database DB { get; set; }

        /*
         TP 2 :
            Reprendre le TP du juste prix et ajouter un tableau des meilleurs scores 
            (c'est une liste qui contient des instances d'une classe User, cette dernière contenant le pseudo de la personne qui joue et son score).

            On cherche alors à mettre à jour ce tableau des meilleurs scores 
            de sorte qu'on voit toujours les 5 meilleurs scores (et le pseudo des joueurs/euses)

            On doit ensuite Sérialiser ce tableau à chaque fois qu'il est mis à jour et le Désérialiser à chaque fois qu'on relance le jeu
        */

        public MainWindow()
        {
            InitializeComponent();

            MinPrix = 0;
            MaxPrix = 100;
            Random random = new Random();
            CurPrix = random.Next(MinPrix, MaxPrix + 1);
            Tentatives = 0;
            CurrentUser = new User(User.NameDefault, Tentatives);
            DB = new Database();
            DB.Deserialize();
            DisplayDBOnScreen();
        }

        private void UserNumberAction_Click(object sender, RoutedEventArgs e)
        {
            // Vérifications du champ en entrée
            if (UserNumberEntry.Text == "")
            {
                MessageBox.Show("Le champ d'entrée ne peut être vide!", "Juste-Prix", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!int.TryParse(UserNumberEntry.Text, out int userNumber))
            {
                MessageBox.Show("Le champ d'entrée est incorrect!", "Juste-Prix", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (userNumber < MinPrix)
            {
                MessageBox.Show("Le champ d'entrée doit être supérieur ou égal a 0!", "Juste-Prix", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (userNumber > MaxPrix)
            {
                MessageBox.Show("Le champ d'entrée doit être inférieur ou égal a 100!", "Juste-Prix", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Ici, le nombre a été chargé sans problèmes, donc on augmente le nombre de tentatives
            Tentatives++;

            if (userNumber != CurPrix)
            {
                if (userNumber < CurPrix)
                    MessageBox.Show("C'est plus!", "Juste-Prix", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show("C'est moins!", "Juste-Prix", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                CurrentUser.Score = Tentatives;
                DB.Users.Add(CurrentUser);
                DB.Serialize();

                DisplayDBOnScreen();
                MessageBox.Show("Le prix a été trouvé par " + CurrentUser.Name + " avec " + CurrentUser.Score + " Tentatives!", "Juste-Prix", MessageBoxButton.OK, MessageBoxImage.Information);
                ResetJustePrix();
            }
        }

        private void UserNameAction_Click(object sender, RoutedEventArgs e)
        {
            if (UserNameEntry.Text == "")
            {
                MessageBox.Show("Le pseudo entré ne peut être vide!", "Juste-Prix", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            if (Tentatives != 0)
            {
                MessageBox.Show("Une partie avait déjà commencé, on redémarre la partie!", "Juste-Prix", MessageBoxButton.OK, MessageBoxImage.Warning);
                ResetJustePrix();
            }

            CurrentUser.Name = UserNameEntry.Text;
        }

        public void ResetJustePrix()
        {
            Random random = new Random();
            CurPrix = random.Next(MinPrix, MaxPrix + 1);
            Tentatives = 0;
        }

        /* Affiche les meilleurs scores de la DB */
        public void DisplayDBOnScreen()
        {
            List<User> ASC = DB.FilterScores();

            DisplayedScores.Text = "";
            for (int userIndex = 0; userIndex < ASC.Count; userIndex++)
            {
                if (userIndex > DisplayedUsersMax)
                    break;

                User user = ASC[userIndex];
                DisplayedScores.Text += user.Name + " " + user.Score + "\n\n";
            }
        }
    }
}
