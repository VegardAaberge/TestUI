using System;
using System.IO;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using TestUI.Strings;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace TestUI.UITests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void CanNavigate()
        {
            AppResult[] results = app.WaitForElement(c => c.Marked("Welcome to Trips!"));
            app.Screenshot("Welcome screen.");
            Assert.IsTrue(results.Any());

            app.Tap(AutomationId.TripsButton);
            results = app.WaitForElement(c => c.Marked(AutomationId.AddNewButton));
            Assert.IsTrue(results.Any());

            app.Tap(c => c.Marked(AutomationId.AddNewButton));
            results = app.WaitForElement(c => c.Marked(AutomationId.EntryNotes));
            Assert.IsTrue(results.Any());

            app.EnterText(c => c.Marked(AutomationId.EntryTitle), "Title");
            app.ClearText(c => c.Marked(AutomationId.EntryRating));
            app.EnterText(c => c.Marked(AutomationId.EntryRating), "5");
            app.EnterText(c => c.Marked(AutomationId.EntryNotes), "Here are some notes");
            app.Tap(c => c.Marked(AutomationId.AddDetailsSaveButton));

            Thread.Sleep(1000);
            app.TapCoordinates(300, 200);
            app.TapCoordinates(300, 250);
            app.TapCoordinates(300, 300);
            results = app.WaitForElement(c => c.Marked(AutomationId.TripDetailsStack));
            Assert.IsTrue(results.Any());

            Thread.Sleep(1000);
            app.Back();
            results = app.WaitForElement(c => c.Marked(AutomationId.TripsListView));
            Assert.IsTrue(results.Any());
        }
    }
}
