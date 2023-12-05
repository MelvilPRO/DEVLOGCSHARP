using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debut_WPF
{
    public class Music
    {
        public string Title { get; set; }
        public EMusics Genre { get; set; }
        public string Artist { get; set; }
        public int Views { get; set; }

        public Music(string title, EMusics genre, string artist, int views)
        {
            Title = title;
            Genre = genre;
            Artist = artist;
            Views = views;
        }

        public override string ToString() 
        { 
            string result = Title + " " + EMusicsHelper.GetString(Genre) + " " + Artist + " " + Views;
            return result;
        }
    }
}
