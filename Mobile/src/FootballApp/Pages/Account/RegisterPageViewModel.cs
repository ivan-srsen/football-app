using FootballApp.Exceptions;
using FootballApp.Helpers;
using FootballApp.Models.Requests;
using FootballApp.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;
using System;
using System.Threading.Tasks;

namespace FootballApp.Pages.Account
{
    public class RegisterPageViewModel : BaseViewModel
    {
        private readonly ApiService _apiService;
        private readonly IServiceProvider _services;

        public RegisterPageViewModel(ApiService apiService, IServiceProvider services)
        {
            _apiService = apiService;
            _services = services;
            
            PageTitle = "Create account";

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

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }

        private string _lastName;

        public string LastName 
        { 
            get { return _lastName; } 
            set { SetProperty(ref _lastName, value); } 
        }

        public async Task SubmitAsync()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.None)
            {
                // TODO print connection message

                return;
            }

            if (string.IsNullOrEmpty(_firstName))
            {
                // Dialog for validation
                return;
            }

            if(string.IsNullOrEmpty(_lastName))
            {
                // Dialog for validation
                return;
            }

            if (string.IsNullOrEmpty(_email))
            {

            }

            var registerRequest = new RegisterRequest
            {
                FirstName = _firstName,
                LastName = _lastName,
                Email = _email,
                Password = _password,
                CompetitorPosition = 0
            };

            try
            {
                var loginPage = _services.GetService<LoginPage>();

                await _apiService.PostRegisterAsync(registerRequest);

                await Application.Current.MainPage.Navigation.PopAsync();
                await Application.Current.MainPage.Navigation.PushAsync(loginPage);
            } catch(ApiException ex)
            {
                // TODO print exception if key is present
            }
        }
    }
}
