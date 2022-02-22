using FootballApp.Exceptions;
using FootballApp.Models.Requests;
using FootballApp.Services;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;
using System.Threading.Tasks;

namespace FootballApp.Pages.Registration
{
    public class SignUpPageViewModel : ViewModel
    {
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

        private readonly FootballApiService _apiService;

        public SignUpPageViewModel(FootballApiService apiService)
        {
            _apiService = apiService;

            SubmitCommand = new Command(async () => await SubmitAsync());
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
                await _apiService.PostRegisterAsync(registerRequest);
            } catch(ApiException ex)
            {
                // TODO print exception if key is present
            }
        }
    }
}
