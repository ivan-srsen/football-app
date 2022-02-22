using FootballApp.Helpers.Forms;

namespace FootballApp.Pages.Login
{
    public class LoginPageViewModel : ViewModel
    {
        public LoginPageViewModel()
        {
        }

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
    }
}
