using FootballApp.Pages.Account;
using FootballApp.Pages.App;
using FootballApp.Pages.Calendars;
using FootballApp.Pages.Login;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Hosting;

namespace FootballApp.Pages
{
    public static class ViewModelExtensions
    {
        public static MauiAppBuilder ConfigureViewModels(this MauiAppBuilder builder)
        {
            var services = builder.Services;

            services.AddTransient<LoginPageViewModel>();
            services.AddTransient<RegisterPageViewModel>();
            services.AddTransient<HomePageViewModel>();
            services.AddTransient<AppHomePageViewModel>();
            services.AddTransient<CalendarPageViewModel>();

            return builder;
        }
    }
}
