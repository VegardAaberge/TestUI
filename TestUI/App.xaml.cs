using System;
using Xamarin.Forms;

using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using TestUI.Views;

namespace TestUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new WelcomePage());
        }

        protected override void OnStart()
        {
            AppCenter.Start("ios=3fff152c-2125-4ba2-9ec1-558f522cf827;" +
                  "android=1b74da5c-da7e-41eb-a3a4-fb5fe5bfb740;",
                  typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
