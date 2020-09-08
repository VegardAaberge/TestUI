using System;
using System.Collections.Generic;
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
            }
        }

        MainViewModel ViewModel => BindingContext as MainViewModel;
    }
}
