using Microsoft.Maui.Controls;
using System;

namespace FootballApp.Pages.Registration
{
    public partial class SignupPageView : ContentPage
    {
        private SignUpPageViewModel _vm => BindingContext as SignUpPageViewModel;

        public SignupPageView(SignUpPageViewModel signUpPageViewModel)
        {
            InitializeComponent();

            BindingContext = signUpPageViewModel;
        }

        public async void OnSignupClicked(object sender, EventArgs args)
        {
            
        }

        public void OnSigninClicked(object sender, EventArgs args)
        {

        }
    }
}