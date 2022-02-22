namespace FootballApp.Helpers.Forms.Settings
{
    public interface IPreferences
    {
        public string AccessToken { get; set; }
        public bool IsLoggedIn { get; set; }
    }
}
