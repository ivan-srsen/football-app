using Football.Core.DomainModels;
using Football.Infrastructure.Database.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Football.Api.Features.Games.GamePreviewResponse;

namespace Football.Api.Features.Games
{
    public class GamePreviewQuery : IRequest<GamePreviewResponse>
    { }

    public class GamePreviewResponse
    {
        public IEnumerable<GameEvent> GameEvents { get; set; } = new List<GameEvent>();
        public class GameEvent
        {
            public int Id { get; set; }
            public DateTime DateTime { get; set; }
            public string Team1Name { get; set; }
            public string Team2Name { get; set; }
            public int Team1Score { get; set; }
            public int Team2Score { get; set; }
            public int NumberOfAttendees { get; set; }
            public ParticipationStatus CurrentUserParticipationStatus { get; set; }
        }
    }

    public class GamePreviewQueryHandler : IRequestHandler<GamePreviewQuery, GamePreviewResponse>
    {
        private readonly ApplicationDbContext _dbContext;

        public GamePreviewQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GamePreviewResponse> Handle(GamePreviewQuery request, CancellationToken cancellationToken)
        {
            var games = await _dbContext.Games.Where(g =>
            g.PlayingTime >= DateTime.Now.AddDays(-7) &&
            g.PlayingTime <= DateTime.Now.AddDays(7))
                .Include(c => c.Participations)
                .ToListAsync();

            return new GamePreviewResponse { GameEvents = games.Select(MapToPreviewResponse) };
        }

        private GameEvent MapToPreviewResponse(Game game)
        {

            // TODO set current user participation status based on user id that you'll retrieve from current user context
            return new GameEvent
            {
                Id = game.Id,
                Team1Name = game.Team1Name,
                Team2Name = game.Team2Name,
                DateTime = game.PlayingTime,
                NumberOfAttendees = game.Participations.Where(p => p.Status == ParticipationStatus.Attending).Count()
            };
        }
    }
}
