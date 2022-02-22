using Microsoft.Maui.Essentials;

namespace FootballApp.Services
{
    public class TokenService
    {
		const string _accessTokenKey = "ACCESS_TOKEN_KEY";

		readonly string _defaultAccessTokenValue = "";

		public string AccessToken
		{
			get => Preferences.Get(_accessTokenKey, _defaultAccessTokenValue);
			set => Preferences.Set(_accessTokenKey, value);
		}
	}
}
