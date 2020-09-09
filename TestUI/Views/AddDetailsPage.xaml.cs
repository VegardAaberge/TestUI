using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestUI.Models;
using TestUI.ViewModels;
using Xamarin.Forms;

namespace TestUI.Views
{
    public partial class AddDetailsPage : ContentPage
    {
        public AddDetailsPage(TaskCompletionSource<TripLogEntry> result)
        {
            InitializeComponent();

            BindingContext = new AddDetailsViewModel(result);
        }

        AddDetailsViewModel ViewModel => BindingContext as AddDetailsViewModel;

        void SaveClicked(System.Object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ViewModel.EntryTitle))
            {
                DisplayAlert("Alert", "You need to fill in title", "OK");
            }
            else
            {
                ViewModel.SetResult(true);
                Navigation.PopModalAsync();
            }
        }

        void DiscardClicked(System.Object sender, System.EventArgs e)
        {
            ViewModel.SetResult(false);
            Navigation.PopModalAsync();
        }
    }
}
