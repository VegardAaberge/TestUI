using System;
using Xamarin.Forms;

namespace TestUI.Models
{
    public class TripLogEntry
    {
        public ImageSource Image { get; set; }

        public string Title { get; set; }
        public string Notes { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
