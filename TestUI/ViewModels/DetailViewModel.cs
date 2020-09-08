using System;
using TestUI.Models;
using TestUI.Root;

namespace TestUI.ViewModels
{
    public class DetailViewModel : BaseViewModel
    {
        TripLogEntry _entry;

        public DetailViewModel(TripLogEntry entry)
        {
            Entry = entry;
        }
        
        public TripLogEntry Entry
        {
            get { return _entry; }
            set
            {
                _entry = value;
                OnPropertyChanged();
            }
        }
    }
}
