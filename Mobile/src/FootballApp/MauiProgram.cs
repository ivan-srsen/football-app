using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Extensions.DependencyInjection;
using FootballApp.Services;
using FootballApp.Helpers.Forms.Pages;
using FootballApp.Pages.Account;
using FootballApp.Pages;
using FootballApp.Pages.App;
using FootballApp.Pages.Calendars;

namespace FootballApp
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureViewModels()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				});

			var services = builder.Services;

			services.AddTransient<HomePage>();
			services.AddTransient<RegisterPage>();
			services.AddTransient<LoginPage>();
			services.AddTransient<CalendarPage>();
			services.AddTransient<TabsPage>();
			services.AddTransient<AppHomePage>();
			services.AddScoped<IPages, AppPages>();
			services.AddSingleton<UserService>();
			services.AddScoped<TokenService>();
			services.AddSingleton<ApiService>();

			return builder.Build();
		}
	}
}