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
            GenerateData();
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

        void GenerateData()
        {
            LogEntries.Add(new TripLogEntry
            {
                Title = "Washington Monument",
                Notes = "Amazing!",
                Rating = 3,
                Date = new DateTime(2017, 2, 5),
                Latitude = 38.8895,
                Longitude = -77.0352
            });
            LogEntries.Add(new TripLogEntry
            {
                Title = "Statue of Liberty",
                Notes = "Inspiring!",
                Rating = 4,
                Date = new DateTime(2017, 4, 13),
                Latitude = 40.6892,
                Longitude = -74.0444
            });
            LogEntries.Add(new TripLogEntry
            {
                Title = "Golden Gate Bridge",
                Notes = "Foggy, but beautiful.",
                Rating = 5,
                Date = new DateTime(2017, 4, 26),
                Latitude = 37.8268,
                Longitude = -122.4798
            });
            LogEntries.Add(new TripLogEntry
            {
                Title = "Times Square",
                Notes = "Amazing!",
                Rating = 3,
                Date = new DateTime(2017, 2, 5),
                Latitude = 38.8895,
                Longitude = -77.0352
            });
            LogEntries.Add(new TripLogEntry
            {
                Title = "Mall Of America",
                Notes = "Inspiring!",
                Rating = 4,
                Date = new DateTime(2017, 4, 13),
                Latitude = 40.6892,
                Longitude = -74.0444
            });
            LogEntries.Add(new TripLogEntry
            {
                Title = "Central Park",
                Notes = "Foggy, but beautiful.",
                Rating = 5,
                Date = new DateTime(2017, 4, 26),
                Latitude = 37.8268,
                Longitude = -122.4798
            });
            LogEntries.Add(new TripLogEntry
            {
                Title = "Union Station",
                Notes = "Amazing!",
                Rating = 3,
                Date = new DateTime(2017, 2, 5),
                Latitude = 38.8895,
                Longitude = -77.0352
            });
            LogEntries.Add(new TripLogEntry
            {
                Title = "Las Vegas Strip",
                Notes = "Inspiring!",
                Rating = 4,
                Date = new DateTime(2017, 4, 13),
                Latitude = 40.6892,
                Longitude = -74.0444
            });
            LogEntries.Add(new TripLogEntry
            {
                Title = "Millennium Park",
                Notes = "Foggy, but beautiful.",
                Rating = 5,
                Date = new DateTime(2017, 4, 26),
                Latitude = 37.8268,
                Longitude = -122.4798
            });
            LogEntries.Add(new TripLogEntry
            {
                Title = "Grand Central Terminal",
                Notes = "Amazing!",
                Rating = 3,
                Date = new DateTime(2017, 2, 5),
                Latitude = 38.8895,
                Longitude = -77.0352
            });
            LogEntries.Add(new TripLogEntry
            {
                Title = "Lincoln Park",
                Notes = "Inspiring!",
                Rating = 4,
                Date = new DateTime(2017, 4, 13),
                Latitude = 40.6892,
                Longitude = -74.0444
            });
            LogEntries.Add(new TripLogEntry
            {
                Title = "Magic Kingdom, Walt Disney World",
                Notes = "Foggy, but beautiful.",
                Rating = 5,
                Date = new DateTime(2017, 4, 26),
                Latitude = 37.8268,
                Longitude = -122.4798
            });

            for (int i = 0; i < LogEntries.Count; i++)
            {
                LogEntries[i].Image = ImageSource.FromUri(new Uri("https://picsum.photos/" + (40 - i)));
            }
        }
    }
}
