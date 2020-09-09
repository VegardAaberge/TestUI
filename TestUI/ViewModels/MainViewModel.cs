using System;
using System.Collections.ObjectModel;
using TestUI.Models;
using TestUI.Root;
using Xamarin.Forms;

namespace TestUI.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
        }

        ObservableCollection<TripLogEntry> _logEntries = new ObservableCollection<TripLogEntry>();
        public ObservableCollection<TripLogEntry> LogEntries
        {
            get { return _logEntries; }
            set
            {
                _logEntries = value;
                OnPropertyChanged();
            }
        }
    }
}
