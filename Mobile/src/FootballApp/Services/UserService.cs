namespace FootballApp.Services
{
    public class UserService
    {
        private readonly TokenService _tokenService;

        public UserService(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public bool IsAuthenticated()
        {
            var token = _tokenService.AccessToken;
            
            return !string.IsNullOrEmpty(token);
        }
    }
}
