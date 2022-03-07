using Football.Core.Common;
using Football.Core.ValueObjects;

namespace Football.Core.DomainModels
{
    public class Game : AggregateRoot<int>
    {
        public string Team1Name { get; private set; }
        public string Team2Name { get; private set; }
        public PlayerNumber PlayerNumber { get; private set; }
        public GameResult? GameResult { get; protected set; }
        public DateTime PlayingTime { get; protected set; }
        private List<Participation> _participations = new List<Participation>();
        public IReadOnlyCollection<Participation> Participations => _participations.AsReadOnly();

        public Game(DateTime playingTime, string team1Name, string team2Name, PlayerNumber playerNumber)
        {
            if (playingTime <= DateTime.Now.AddHours(1))
                throw new ArgumentException();

            if(string.IsNullOrEmpty(team1Name))
                throw new ArgumentException();

            if (string.IsNullOrEmpty(team2Name))
                throw new ArgumentException();

            Team1Name = team1Name;
            Team2Name = team2Name;
            PlayingTime = playingTime;
            PlayerNumber = playerNumber;
        }
    }
}
