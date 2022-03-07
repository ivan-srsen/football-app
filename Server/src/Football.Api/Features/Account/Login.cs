using Football.Api.Settings;
using Football.Core.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Football.Api.Features.Account
{
    public class LoginCommand : IRequest<LoginResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public string AccessToken { get; set; }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppSettings _appSettings;

        public LoginCommandHandler(UserManager<ApplicationUser> userManager, AppSettingsProvider appSettingsProvider)
        {
            _userManager = userManager;
            _appSettings = appSettingsProvider.AppSettings;
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
                throw new Exception($"User with email {request.Email} doesn't exist");

            var isValid = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!isValid)
                throw new Exception($"Password for user {request.Email} is not valid");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(token);

            return new LoginResponse { AccessToken = accessToken };
        }
    }
}
