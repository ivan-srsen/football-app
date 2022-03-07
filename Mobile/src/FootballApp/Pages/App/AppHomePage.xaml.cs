using Microsoft.Maui.Controls;

namespace FootballApp.Pages.App
{
    public partial class AppHomePage : ContentPage
    {
        private readonly AppHomePageViewModel _vm;

        public AppHomePage(AppHomePageViewModel vm)
        {
            InitializeComponent();
            
            _vm = vm;
        }
    }
}