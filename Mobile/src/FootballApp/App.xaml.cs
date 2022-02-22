using FootballApp.Helpers.Forms;
using FootballApp.Pages.Login;
using FootballApp.Services;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using Application = Microsoft.Maui.Controls.Application;

namespace FootballApp
{
	public partial class App : Application
	{
        private readonly UserService _userService;
        private readonly MainPage mainPage;
        private readonly LoginPageView loginPageView;

        public App(UserService userService, MainPage mainPage, LoginPageView loginPageView)
		{
			InitializeComponent();

			_userService = userService;
            this.mainPage = mainPage;
            this.loginPageView = loginPageView;
            SetMainPage();
        }

		private void SetMainPage()
        {
            var isSignedIn = _userService.IsAuthenticated();

            if (isSignedIn)
            {
                Current.MainPage = new NavigationPage(this.mainPage);
            }
            else
            {
                Current.MainPage = new NavigationPage(this.loginPageView);
            }
        }
	}
}
