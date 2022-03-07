using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using System;

namespace FootballApp.Pages.Account
{
    public partial class HomePage : ContentPage
    {
        private readonly IServiceProvider _services;

        public HomePage(HomePageViewModel vm, IServiceProvider services)
        {
            InitializeComponent();

            BindingContext = vm;

            _services = services;
        }

        public async void LogIn_Clicked(object sender, EventArgs args)
        {
            var loginPage = _services.GetService<LoginPage>();

            await Navigation.PushAsync(loginPage);
        }

        public async void Register_Clicked(object sender, EventArgs args)
        {
            var registerPage = _services.GetService<RegisterPage>();

            await Navigation.PushAsync(registerPage);
        }
    }
}