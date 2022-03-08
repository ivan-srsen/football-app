namespace Football.Core.DomainModels
{
    public class Participation
    {
        public int Id { get; private set; }
        public Game Game { get; private set; }
        public Player Player { get; private set; }
        public ParticipationStatus Status { get; private set; }

        private Participation() { }

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
