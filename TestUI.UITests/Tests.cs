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
            app = AppInitializer.StartApp(platform, true);
        }

        [Test]
        public void CanNavigate()
        {
            // Wait for welcome screen
            AppResult[] results = app.WaitForElement(c => c.Marked("Welcome to Trips!"));
            app.Screenshot("Welcome screen");
            Assert.IsTrue(results.Any());

            // Tap the trips button
            app.Tap(AutomationId.TripsButton);
            results = app.WaitForElement(c => c.Marked(AutomationId.AddNewButton));
            app.Screenshot("Trips screen");
            Assert.IsTrue(results.Any());

            // Tap the add new button
            app.Tap(c => c.Marked(AutomationId.AddNewButton));
            results = app.WaitForElement(c => c.Marked(AutomationId.EntryNotes));
            Assert.IsTrue(results.Any());

            // Fill in the fields
            app.EnterText(c => c.Marked(AutomationId.EntryTitle), "Title");
            app.ClearText(c => c.Marked(AutomationId.EntryRating));
            app.EnterText(c => c.Marked(AutomationId.EntryRating), "5");
            app.EnterText(c => c.Marked(AutomationId.EntryNotes), "Here are some notes");
            app.Screenshot("Add Details screen");

            // Return from the AddDetailsPage
            app.Tap(c => c.Marked(AutomationId.AddDetailsSaveButton));
            results = app.WaitForElement(c => c.Marked(AutomationId.TripsListView));
            app.Screenshot("Trips with entry");
            Assert.IsTrue(results.Any());

            // Tap the first element
            var item = app.Query(c => c.Marked(AutomationId.TripsListView).Index(0));
            app.Tap(c => c.Text("Title"));
            results = app.WaitForElement(c => c.Marked(AutomationId.TripDetailsStack));
            app.Screenshot("Details Page");
            Assert.IsTrue(results.Any());

            app.SetOrientationLandscape();

            // Return from the details page
            Thread.Sleep(1000);
            app.Back();
            results = app.WaitForElement(c => c.Marked(AutomationId.TripsListView));
            app.Screenshot("Trips with entry landscape");
            Assert.IsTrue(results.Any());
        }
    }
}
