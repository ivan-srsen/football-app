using FootballApp.Helpers.Forms;
using FootballApp.Pages.Account;
using FootballApp.Pages.App;
using FootballApp.Pages.Login;
using FootballApp.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using System;
using Application = Microsoft.Maui.Controls.Application;

namespace FootballApp
{
	public partial class App : Application
	{
        private readonly UserService _userService;
        
        private readonly IServiceProvider _services;

        public App(UserService userService, IServiceProvider services, TokenService tokenService)
		{
			InitializeComponent();

            // TODO remove
            tokenService.AccessToken = "";

			_userService = userService;
            _services = services;
            
            SetMainPage();
        }

		private void SetMainPage()
        {
            var authed = _userService.IsAuthenticated();

            if (authed) {
                var appHomePage = _services.GetService<AppHomePage>();

                Current.MainPage = new NavigationPage(appHomePage);
            }
            else
            {
                var homePage = _services.GetService<HomePage>();

                Current.MainPage = new NavigationPage(homePage);
            }
        }
	}
}
