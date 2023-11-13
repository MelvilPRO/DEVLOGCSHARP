using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Projet
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
            DB.Musics.Add(new Music("Bidule", EGenre.Rap, "Artist"));
            DB.Musics.Add(new Music("Thomasy", EGenre.Rock, "Mansion"));
            DB.Musics.Add(new Music("Sylvio", EGenre.Jazz, "Hello"));
            DB.Musics.Add(new Music("Truc", EGenre.Pop, "Hi"));
            DB.Musics.Add(new Music("Hehehe", EGenre.Rap, "afnf"));
            DB.Musics.Add(new Music("zefzes", EGenre.Rock, "jzoebgj"));
            DB.Musics.Add(new Music("dtnbipa", EGenre.Jazz, "hioaf"));
            DB.Musics.Add(new Music("sqnfoi", EGenre.Pop, "sqonf"));

            /*
            List<Music> DBFiltered = DB.FilterGenre(EGenre.Jazz);
            for (int musicIndex = 0; musicIndex < DBFiltered.Count; musicIndex++)
            {
                Music currentMusic = DBFiltered[musicIndex];
                Console.WriteLine("Titre: " + currentMusic.Title + " Genre: " + currentMusic.Genre + " Artiste: " + currentMusic.Artist);
            }
            */

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
            for (int musicIndex = 0; musicIndex < DBFiltered.Count; musicIndex++)
            {
                Music currentMusic = DBFilteredTitles[musicIndex];
                Console.WriteLine("Titre: " + currentMusic.Title + " Genre: " + currentMusic.Genre + " Artiste: " + currentMusic.Artist);
            }
        }
    }
}
