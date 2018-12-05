using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TizenWatchfaceApp1
{
    public class ClockViewModel : INotifyPropertyChanged
    {
        private DateTime time;

        public DateTime Time
        {
            get => time;
            set
            {
                if (time != value)
                {
                    time = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
