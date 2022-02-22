using Microsoft.Maui.Essentials;

namespace FootballApp.Helpers.Forms.Settings
{
    public class AppPreferences : IPreferences
    {
		const string _accessTokenKey = "ACCESS_TOKEN_KEY";

		readonly string _defaultAccessTokenValue = "";

		public string AccessToken
		{
			get => Preferences.Get(_accessTokenKey, _defaultAccessTokenValue);
			set => Preferences.Set(_accessTokenKey, value);
		}

		const string _isLoggedInKey = "LOGGED_IN_KEY";

		readonly bool _defaultIsLoggedInValue = false;

		public bool IsLoggedIn
        {
			get => Preferences.Get(_isLoggedInKey, _defaultIsLoggedInValue);
			set => Preferences.Set(_isLoggedInKey, _defaultIsLoggedInValue);
        }
	}
}
