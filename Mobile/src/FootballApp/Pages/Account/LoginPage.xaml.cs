using FootballApp.Helpers.Forms;
using FootballApp.Pages.Login;
using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;

namespace FootballApp.Pages.Account
{
    public partial class LoginPage : ContentPage
    {
        private readonly RegisterPage _signupPageView;

        public LoginPage(LoginPageViewModel loginPageViewModel, RegisterPage signupPageView)
        {
            InitializeComponent();

            BindingContext = loginPageViewModel;
            _signupPageView = signupPageView;
        }

        public void OnLoginClicked(object sender, EventArgs args)
        {

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
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