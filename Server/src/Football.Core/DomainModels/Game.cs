using Football.Core.Common;
using Football.Core.ValueObjects;

namespace Football.Core.DomainModels
{
    public class Game : Entity
    {
        public PlayerNumber PlayerNumber { get; private set; }
        public GameResult? GameResult { get; protected set; }
        public DateTime PlayingTime { get; protected set; }

        private List<Participation> _participations = new List<Participation>();
        public IReadOnlyCollection<Participation> Participations => _participations.AsReadOnly();

        protected Game() { }

        public Game(DateTime playingTime, PlayerNumber playerNumber)
        {
            if (playingTime <= DateTime.Now.AddHours(1))
                throw new ArgumentException();

            PlayingTime = playingTime;
            PlayerNumber = playerNumber;
        }

        public void EnrollAllPlayers(IEnumerable<Player> players)
        {
            foreach(var player in players)
            {
                if (_participations.Any(x => x.Player == player))
                    throw new InvalidOperationException("Some players are already enrolled");

                var participation = new Participation(this, player);

                _participations.Add(participation);
            }
        }
    }
}
