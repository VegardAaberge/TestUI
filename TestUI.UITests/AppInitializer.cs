using System;
using Xamarin.UITest;
using Xamarin.UITest.Configuration;
using Xamarin.UITest.Queries;

namespace TestUI.UITests
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform, bool clearData)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp.Android.EnableLocalScreenshots().StartApp(clearData ? AppDataMode.Clear : AppDataMode.DoNotClear);
            }

            return ConfigureApp.iOS.EnableLocalScreenshots().StartApp(clearData ? AppDataMode.Clear : AppDataMode.DoNotClear);
        }
    }
}