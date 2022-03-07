using Football.Core.Common;

namespace Football.Core.ValueObjects
{
    public class GameResult : ValueObject<GameResult>
    {
        public int Team1Score { get; }
        public int Team2Score { get; }

        public GameResult(int team1Score, int team2Score)
        {
            if (team1Score < 0 || Team2Score < 0)
                throw new InvalidOperationException();

            Team1Score = team1Score;
            Team2Score = team2Score;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Team1Score;
            yield return Team2Score;
        }
    }
}
