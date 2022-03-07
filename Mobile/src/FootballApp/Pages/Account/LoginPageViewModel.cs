using FootballApp.Exceptions;
using FootballApp.Helpers;
using FootballApp.Models.Requests;
using FootballApp.Pages.App;
using FootballApp.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;
using System;
using System.Threading.Tasks;

namespace FootballApp.Pages.Login
{
    public class LoginPageViewModel : BaseViewModel
    {
        private readonly IServiceProvider _services;
        private readonly ApiService _apiService;

        public LoginPageViewModel(IServiceProvider services, ApiService apiService)
        {
            PageTitle = AppResources.Login;

            _services = services;
            _apiService = apiService;

            SubmitCommand = new Command(async () => await SubmitAsync());
        }

        public Command SubmitCommand { get; }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public async Task SubmitAsync()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.None)
            {
                // TODO print connection message

                return;
            }

            if (string.IsNullOrEmpty(_email))
            {

            }

            if (string.IsNullOrEmpty(_password))
            {

            }

            var loginRequest = new LoginRequest
            {
                Email = _email,
                Password = _password
            };

            try
            {
                var tabsPage = _services.GetService<TabsPage>();

                await _apiService.PostLoginAsync(loginRequest);

                Application.Current.MainPage = tabsPage;
            }
            catch (ApiException ex)
            {
                // TODO print exception if key is present
            }
        }
    }
}
