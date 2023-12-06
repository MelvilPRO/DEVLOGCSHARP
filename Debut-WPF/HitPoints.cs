using System;
using System.ComponentModel;

namespace Debut_WPF
{
    public class HitPoints : INotifyPropertyChanged
    {
        private string hp;

        public string HP
        {
            get { return hp; }
            set
            {
                if (hp != value)
                {
                    hp = value;
                    NotifyPropertyChanged(nameof(HP));
                }
            }
        }

        public HitPoints()
        {
            HP = "100";
        }

        public HitPoints(string hp)
        {
            HP = hp;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}