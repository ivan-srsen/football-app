using FootballApp.Pages.Account;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace FootballApp.Helpers.Forms.Pages
{
    public class AppPages : IPages
    {
        private readonly RegisterPage _registerPage;
        private readonly LoginPage _loginPage;

        public AppPages(RegisterPage registerPage, LoginPage loginPage)
        {
            _registerPage = registerPage;
            _loginPage = loginPage;
        }

        NavigationPage mainPage
        {
            get => Application.Current.MainPage as NavigationPage;
            set => Application.Current.MainPage = value;
        }

        public void OpenLogin() =>
            SwitchMainPage(_loginPage);

        public void OpenMain() =>
            SwitchMainPage(new MainPage());

        public async Task OpenSignup() =>
            await pushPage(_registerPage);

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
