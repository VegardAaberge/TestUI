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
            app.Screenshot("Welcome screen.");
            Assert.IsTrue(results.Any());

            // Tap the trips button
            app.Tap(AutomationId.TripsButton);
            results = app.WaitForElement(c => c.Marked(AutomationId.AddNewButton));
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

            // Return from the AddDetailsPage
            app.Tap(c => c.Marked(AutomationId.AddDetailsSaveButton));
            results = app.WaitForElement(c => c.Marked(AutomationId.TripsListView));
            Assert.IsTrue(results.Any());

            // Tap the first element
            var length = app.Query(c => c.Marked(AutomationId.TripsListView).Child()).Length;
            Assert.IsTrue(length == 1);
            var item = app.Query(c => c.Marked(AutomationId.TripsListView).Index(0));
            app.Tap(c => c.Text("Title"));
            results = app.WaitForElement(c => c.Marked(AutomationId.TripDetailsStack));
            Assert.IsTrue(results.Any());

            // Return from the details page
            Thread.Sleep(1000);
            app.Back();
            results = app.WaitForElement(c => c.Marked(AutomationId.TripsListView));
            Assert.IsTrue(results.Any());
        }

        Func<AppQuery, AppQuery> GetElementFromList(string automationId, int index)
        {
            Func<AppQuery, AppQuery> itemInListView = null;

            if (platform == Platform.Android)
                itemInListView = x => x.Class("ViewCellRenderer_ViewCellContainer").Index(index);
            else if (platform == Platform.iOS)
                itemInListView =
                x => x.Marked(automationId).Index(0);

            return itemInListView;
        }
    }
}
