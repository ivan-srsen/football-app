using Football.Core.Common;

namespace Football.Core.DomainModels
{
    public class Participation : AggregateRoot<int>
    {
        public Game Game { get; private set; }
        public Player Player { get; private set; }
        public ParticipationStatus Status { get; private set; }

        public Participation(Game game, Player player)
        {
            Game = game;
            Player = player;

            Status = ParticipationStatus.Waiting;
        }
    }

    public enum ParticipationStatus
    {
        Waiting,
        Rejected,
        Attending
    }
}
