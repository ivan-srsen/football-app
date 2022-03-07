using Microsoft.Maui.Controls;
using System;

namespace FootballApp.Pages.Account
{
    public partial class RegisterPage : ContentPage
    {
        private RegisterPageViewModel _vm => BindingContext as RegisterPageViewModel;

        public RegisterPage(RegisterPageViewModel registerPageViewModel)
        {
            InitializeComponent();

            BindingContext = registerPageViewModel;
        }

        public async void OnSignupClicked(object sender, EventArgs args)
        {
            
        }

        public void OnSigninClicked(object sender, EventArgs args)
        {

        }
    }
}