using System;
using System.Collections.Generic;
using TestUI.Models;
using TestUI.ViewModels;
using Xamarin.Forms;

namespace TestUI.Views
{
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage(TripLogEntry selectedItem)
        {
            InitializeComponent();

            BindingContext = new DetailViewModel(selectedItem);
        }

        DetailViewModel ViewModel => BindingContext as DetailViewModel;
    }
}
