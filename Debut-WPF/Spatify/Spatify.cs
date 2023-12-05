using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Debut_WPF
{
    public class Spatify
    {
        public static void SeparateTP()
        {
            /*
            Plateforme d'écoute de musique Spatify

            Classe Music


            Title
            Genre(enum) (niveau volcan : ou liste de Genre)
            Artist

            Classe Database

            Musics(liste de Music)
            + Faire des requêtes LinQ : 
            + Une méthode pour obtenir toutes les musiques d'un genre spécifique
            + Une méthode qui prend en paramètre un string, et qui affiche les musiques qui contiennent la chaîne de caractères tapée(les trier par vues, dans la même méthode ou dans une autre)
            */

            Database DB = new Database();
            DB.Musics.Add(new Music("Bidule", EMusics.Rap, "Artist", 100));
            DB.Musics.Add(new Music("Thomas", EMusics.Rock, "Mansion", 300));
            DB.Musics.Add(new Music("Sylvio", EMusics.Jazz, "Hello", 200));
            DB.Musics.Add(new Music("Truc", EMusics.Pop, "Hi", 9999));
            DB.Musics.Add(new Music("Hehehe", EMusics.Rap, "afnf", 1));
            DB.Musics.Add(new Music("zefzes", EMusics.Rock, "jzoebgj", 1002));
            DB.Musics.Add(new Music("dtnbipa", EMusics.Jazz, "hioaf",100000));
            DB.Musics.Add(new Music("sqnfoi", EMusics.Pop, "sqonf", 97878976));

            /*
            List<Music> DBFiltered = DB.FilterGenre(EMusics.Jazz);
            for (int musicIndex = 0; musicIndex < DBFiltered.Count; musicIndex++)
            {
                Music currentMusic = DBFiltered[musicIndex];
                Console.WriteLine("Titre: " + currentMusic.Title + " Genre: " + currentMusic.Genre + " Artiste: " + currentMusic.Artist);
            }
            */

            /*
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Veuillez entrer un filtre pour les titres");
            Console.WriteLine("-----------------------------------");

            string filter = "";
            try
            {
                filter = Console.ReadLine();
            } catch
            {
                Console.WriteLine("Une erreur a eu lieu");
                return;
            }

            
            List<Music> DBFilteredTitles = DB.FilterTitle(filter);
            for (int musicIndex = 0; musicIndex < DBFilteredTitles.Count; musicIndex++)
            {
                Music currentMusic = DBFilteredTitles[musicIndex];
                Console.WriteLine("Titre: " + currentMusic.Title + " Genre: " + currentMusic.Genre + " Artiste: " + currentMusic.Artist);
            }
            */

            List<Music> DBFilteredViews = DB.FilterMoreViews();
            for (int musicIndex = 0; musicIndex < DBFilteredViews.Count; musicIndex++)
            {
                Music currentMusic = DBFilteredViews[musicIndex];
                Console.WriteLine("Titre: " + currentMusic.Title + " Genre: " + currentMusic.Genre + " Artiste: " + currentMusic.Artist + " Nombre de vues: " + currentMusic.Views);
            }


        }
    }
}
