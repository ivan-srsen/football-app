using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Extensions.DependencyInjection;
using FootballApp.Services;
using FootballApp.Helpers.Forms.Pages;
using FootballApp.Pages.Registration;
using FootballApp.Pages.Login;
using FootballApp.Helpers.Forms;
using System.Net.Http;
using System;

namespace FootballApp
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				});

			var services = builder.Services;

			services.AddSingleton<MainPage>();
			services.AddSingleton<LoginPageView>();
			services.AddSingleton<LoginPageViewModel>();
			services.AddScoped<IPages, AppPages>();
			services.AddSingleton<UserService>();
			services.AddScoped<TokenService>();
			services.AddSingleton<SignupPageView>();
			services.AddSingleton<SignUpPageViewModel>();
			services.AddHttpClient<FootballApiService>(c => c.BaseAddress= new Uri("http://10.0.2.2:7222")).ConfigurePrimaryHttpMessageHandler(GetInsecureHandler);

			return builder.Build();
		}

		public static HttpClientHandler GetInsecureHandler()
		{
			HttpClientHandler handler = new HttpClientHandler();
			handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
			{
				if (cert.Issuer.Equals("CN=localhost"))
					return true;
				return errors == System.Net.Security.SslPolicyErrors.None;
			};
			return handler;
		}
	}
}