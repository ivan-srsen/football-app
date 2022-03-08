using Football.Core.Common;

namespace Football.Core.ValueObjects
{
    public class GameResult : ValueObject<GameResult>
    {
        public int Team1Score { get; private set; }
        public int Team2Score { get; private set; }

        protected GameResult() { }

        private GameResult(int team1Score, int team2Score)
            :this()
        {
            Team1Score = team1Score;
            Team2Score = team2Score;
        }

        public static GameResult Create(int team1Score, int team2Score)
        {
            if (team1Score < 0 || team2Score < 0)
                throw new InvalidOperationException();

            return new GameResult(team1Score, team2Score);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Team1Score;
            yield return Team2Score;
        }
    }
}
