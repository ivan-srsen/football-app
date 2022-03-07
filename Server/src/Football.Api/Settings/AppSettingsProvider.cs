using Microsoft.Extensions.Options;

namespace Football.Api.Settings
{
    public class AppSettingsProvider
    {
        public AppSettings AppSettings { get; set; }
        
        public AppSettingsProvider(IOptions<AppSettings> appSettings)
        {
            AppSettings = appSettings.Value;
        }
    }
}
