using FootballApp.Pages.Login;
using FootballApp.Pages.Registration;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System.Drawing;
using System.Threading.Tasks;

namespace FootballApp.Helpers.Forms.Pages
{
    public class AppPages : IPages
    {
        private readonly SignupPageView _signupPageView;
        private readonly LoginPageView _loginPageView;

        public AppPages(SignupPageView signupPageView, LoginPageView loginPageView)
        {
            _signupPageView = signupPageView;
            _loginPageView = loginPageView;
        }

        NavigationPage mainPage
        {
            get => Application.Current.MainPage as NavigationPage;
            set => Application.Current.MainPage = value;
        }

        public void OpenLogin() =>
            SwitchMainPage(_loginPageView);

        public void OpenMain() =>
            SwitchMainPage(new MainPage());

        public async Task OpenSignup() =>
            await pushPage(_signupPageView);

        async Task pushPage(Page newPage, string title = null, bool isModal = false)
        {
            if (isModal)
            {
                await mainPage.Navigation.PushModalAsync(
                    GetNavigationPage(newPage, title));
            }
            else
            {
                await mainPage.Navigation.PushAsync(
                    GetNavigationPage(newPage, title));
            }
        }

        private void SwitchMainPage(Page newPage) => mainPage = GetNavigationPage(newPage);

        private NavigationPage GetNavigationPage(Page page, string title = null) => new NavigationPage(page);
    }
}
