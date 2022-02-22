using FootballApp.Helpers.Forms.Pages;
using FootballApp.Helpers.Forms.Settings;

namespace FootballApp.Helpers.Forms
{
    public class PlatformService : IPlatformService
    {
		public IPreferences Preferences { get; set; }
		public IPages Pages { get; set; }

		public PlatformService(IPages pages)
		{
			Preferences = new AppPreferences();
			Pages = pages;
		}
	}
}
