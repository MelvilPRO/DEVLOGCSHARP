using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debut_WPF
{
    public class Database
    {
        public List<Music> Musics { get; set; }

        public Database() 
        { 
            Musics = new List<Music>();
        }

        public Database(List<Music> musics)
        {
            Musics = musics;
        }

        public void InsertFakeMusics()
        {
            Musics.Add(new Music("Bidule", EMusics.Rap, "Artist", 100));
            Musics.Add(new Music("Thomas", EMusics.Rock, "Mansion", 300));
            Musics.Add(new Music("Sylvio", EMusics.Jazz, "Hello", 200));
            Musics.Add(new Music("Truc", EMusics.Pop, "Hi", 9999));
            Musics.Add(new Music("Hehehe", EMusics.Rap, "afnf", 1));
            Musics.Add(new Music("zefzes", EMusics.Rock, "jzoebgj", 1002));
            Musics.Add(new Music("dtnbipa", EMusics.Jazz, "hioaf", 100000));
            Musics.Add(new Music("sqnfoi", EMusics.Pop, "sqonf", 97878976));
        }

        public List<Music> FilterGenre(EMusics genre)
        {
            List <Music> listQuery = Musics.Where(musicElement => musicElement.Genre == genre).ToList();
            return listQuery;
        }

        public List<Music> FilterTitle(string filter)
        {
            List<Music> listQuery = Musics.Where(musicElement => musicElement.Title.Contains(filter)).ToList();
            return listQuery;
        }

        public List<Music> FilterMoreViews()
        {
            List<Music> listCopy = new List<Music>(Musics);

            List<Music> listQuery = new List<Music>();
            while (listCopy.Count > 0)
            {
                int numberOfViews = -1;
                int musicIndex = 0;

                for (int loopIndex = 0; loopIndex < listCopy.Count; loopIndex++)
                {
                    if (listCopy[loopIndex].Views > numberOfViews)
                    {
                        numberOfViews = listCopy[loopIndex].Views;
                        musicIndex = loopIndex;
                    }
                }

                listQuery.Add(listCopy[musicIndex]);
                listCopy.RemoveAt(musicIndex);
            }

            return listQuery;
        }

        public override string ToString()
        {
            string result = "";

            foreach (Music music in Musics)
            {
                result += music.ToString() + "\n";
            }

            return result;
        }
    }
}
