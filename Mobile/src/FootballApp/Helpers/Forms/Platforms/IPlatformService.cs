using FootballApp.Helpers.Forms.Pages;
using FootballApp.Helpers.Forms.Settings;

namespace FootballApp.Helpers.Forms
{
    public interface IPlatformService
    {
        IPreferences Preferences { get; set; }
        IPages Pages { get; set; }
    }
}
