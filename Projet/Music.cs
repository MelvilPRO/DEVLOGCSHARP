using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    public class Music
    {
        public string Title { get; set; }
        public EGenre Genre { get; set; }
        public string Artist { get; set; }
        public int Views { get; set; }

        public Music(string title, EGenre genre, string artist, int views)
        {
            this.Title = title;
            this.Genre = genre;
            this.Artist = artist;
            this.Views = views;
        }
    }
}
