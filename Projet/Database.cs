using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
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
            this.Musics = musics;
        }

        public List<Music> FilterGenre(EGenre genre)
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
    }
}
