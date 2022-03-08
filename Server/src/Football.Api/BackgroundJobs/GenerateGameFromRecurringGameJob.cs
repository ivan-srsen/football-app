using Football.Core.DomainModels;
using Football.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;
using Quartz;

namespace Football.Api.BackgroundJobs
{
    [DisallowConcurrentExecution]
    public class GenerateGameFromRecurringGameJob : IJob
    {
        private readonly ApplicationDbContext _dbContext;

        public GenerateGameFromRecurringGameJob(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var recurringGames = await _dbContext.RecurringGames.ToListAsync();

            var games = new List<Game>();

            foreach(var recurringGame in recurringGames)
            {
                var game = new Game(DateTime.Now, recurringGame.Team1Name, recurringGame.Team2Name, recurringGame.PlayerNumber);
                var players = await _dbContext.Players.ToListAsync();

                game.EnrollAllPlayers(players);

                games.Add(game);
            }

            if(games.Any())
                await _dbContext.Games.AddRangeAsync(games);
        }
    }
}
