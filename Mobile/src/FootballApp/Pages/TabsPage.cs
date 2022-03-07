using FootballApp.Pages.Calendars;
using FootballApp.Pages.Tests;
using Microsoft.Maui.Controls;

namespace FootballApp.Pages
{
    public class TabsPage : TabbedPage
    {
        public TabsPage(CalendarPage calendarPage)
        {
            var calendarNavPage = new NavigationPage(calendarPage)
            {
                Title = "Calendar"
            };

            Children.Add(calendarNavPage);

            var testNavPage = new NavigationPage(new TestPage())
            {
                Title = "Test"
            };

            Children.Add(testNavPage);
        }
    }
}
