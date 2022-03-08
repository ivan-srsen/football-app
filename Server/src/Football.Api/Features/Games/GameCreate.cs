using Football.Core.Common;
using Football.Core.DomainModels;
using Football.Infrastructure.Database.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Football.Api.Features.Games
{
    public class GameCreateCommand : IRequest
    {
        public string Team1Name { get; set; }
        public string Team2Name { get; set; }
        public int PlayerNumber { get; set; }
        public DateTime PlayingTime { get; set; }
    }

    public class GameCreateCommandHandler : IRequestHandler<GameCreateCommand>
    {
        private readonly ApplicationDbContext _dbContext;

        public GameCreateCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(GameCreateCommand request, CancellationToken cancellationToken)
        {
            var players = await _dbContext.Players.ToListAsync();

            var playerNumber = Enumeration.FromValue<PlayerNumber>(request.PlayerNumber);

            var game = new Game(request.PlayingTime, request.Team1Name, request.Team2Name, playerNumber);
            
            game.EnrollAllPlayers(players);

            await _dbContext.Games.AddAsync(game);

            return Unit.Value;
        }
    }
}
