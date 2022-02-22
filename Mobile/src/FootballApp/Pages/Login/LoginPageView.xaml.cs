using FootballApp.Helpers.Forms;
using FootballApp.Pages.Registration;
using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;

namespace FootballApp.Pages.Login
{
    public partial class LoginPageView : ContentPage
    {
        private readonly SignupPageView _signupPageView;

        public LoginPageView(LoginPageViewModel loginPageViewModel, SignupPageView signupPageView)
        {
            InitializeComponent();

            BindingContext = loginPageViewModel;
            _signupPageView = signupPageView;
        }

        public void OnLoginClicked(object sender, EventArgs args)
        {

        }

        public async void OnSignupClicked(object sender, EventArgs args)
        {
            await pushPage(_signupPageView);
        }

        async Task pushPage(Page newPage, string title = null, bool isModal = false)
        {
            if (isModal)
            {
                await Navigation.PushModalAsync(
                    GetNavigationPage(newPage, title));
            }
            else
            {
                await Navigation.PushAsync(
                    GetNavigationPage(newPage, title));
            }
        }

        private NavigationPage GetNavigationPage(Page page, string title = null) => new NavigationPage(page);
    }
}