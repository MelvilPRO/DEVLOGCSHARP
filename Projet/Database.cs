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
    }
}
