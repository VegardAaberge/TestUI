using System;
using System.Threading.Tasks;
using TestUI.Models;
using Xamarin.Forms;

namespace TestUI.ViewModels
{
    public class AddDetailsViewModel
    {
        TaskCompletionSource<TripLogEntry> Result { get; set; }

        public AddDetailsViewModel(TaskCompletionSource<TripLogEntry> result)
        {
            Result = result;
        }

        public void SetResult(bool isSaved)
        {
            if (isSaved)
            {
                Random random = new Random();
                var randInt = random.Next(0, 10);

                Result.TrySetResult(new TripLogEntry
                {
                    Title = EntryTitle,
                    Date = DateTime.Now,
                    Image = ImageSource.FromUri(new Uri("https://picsum.photos/" + (40 - randInt))),
                    Notes = EntryNotes,
                    Rating = EntryRating,
                });
            }
            else
            {
                Result.TrySetResult(null);
            }
        }

        public string EntryTitle { get; set; }

        public int EntryRating { get; set; }

        public string EntryNotes { get; set; }
    }
}
