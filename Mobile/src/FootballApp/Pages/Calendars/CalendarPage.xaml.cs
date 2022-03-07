using Microsoft.Maui.Controls;

namespace FootballApp.Pages.Calendars
{
    public partial class CalendarPage : ContentPage
    {
        public CalendarPage(CalendarPageViewModel vm)
        {
            InitializeComponent();

            BindingContext = vm;
        }
    }
}