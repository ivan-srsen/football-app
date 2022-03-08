using Football.Core.DomainModels;
using Football.Core.Exceptions;
using Football.Core.Users;
using Football.Infrastructure.Database.Contexts;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Football.Api.Features.Account
{
    public class RegistrationCommand : IRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CompetitorPosition { get; set; }
    }

    public class RegistrationCommandHandler : IRequestHandler<RegistrationCommand>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public RegistrationCommandHandler(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<Unit> Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {
            var email = request.Email;
            var password = request.Password;
            var firstName = request.FirstName;
            var lastName = request.LastName;
            var competitorPosition = request.CompetitorPosition;

            var user = new ApplicationUser 
            { 
                Email = email,
                UserName = email
            };

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
                throw new ValidationException(result.Errors.First().Description);

            var competitor = new Player(firstName, lastName, competitorPosition);
            
            await _context.Players.AddAsync(competitor, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
