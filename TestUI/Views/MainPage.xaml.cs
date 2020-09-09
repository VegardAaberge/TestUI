using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using TestUI.Models;
using TestUI.ViewModels;
using Xamarin.Forms;

namespace TestUI.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainViewModel();
        }

        void ListView_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is TripLogEntry tripLogEntry)
            {
                Navigation.PushAsync(new DetailsPage(tripLogEntry));
                listView.SelectedItem = null;
            }
        }

        void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var setResult = new TaskCompletionSource<TripLogEntry>();
                await Navigation.PushModalAsync(new NavigationPage(new AddDetailsPage(setResult)));

                var newEntry = await setResult.Task;
                if (newEntry != null)
                {
                    var logEntries = ViewModel.LogEntries.ToList();
                    logEntries.Add(newEntry);
                    ViewModel.LogEntries = new ObservableCollection<TripLogEntry>(logEntries);
                }
            });
        }

        MainViewModel ViewModel => BindingContext as MainViewModel;
    }
}
