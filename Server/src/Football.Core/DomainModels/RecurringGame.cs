using Football.Core.Common;

namespace Football.Core.DomainModels
{
    public class RecurringGame : AggregateRoot<int>
    {
        public string Team1Name { get; private set; }
        public string Team2Name { get; private set; }
        public PlayerNumber PlayerNumber { get; private set; }
        public WeekDay Day { get; private set; }
        public DateTime PlayingTime { get; protected set; }
        public DateTime FromDate { get; protected set; }
        public DateTime ToDate { get; protected set; }

        public RecurringGame(
            string team1Name,
            string team2Name,
            DateTime playingTime,  
            PlayerNumber playerNumber)
        {
            if (playingTime <= DateTime.Now.AddHours(1))
                throw new ArgumentException();

            if (string.IsNullOrEmpty(team1Name))
                throw new ArgumentException();

            if (string.IsNullOrEmpty(team2Name))
                throw new ArgumentException();

            Team1Name = team1Name;
            Team2Name = team2Name;
            PlayingTime = playingTime;
            PlayerNumber = playerNumber;
        }
        
        public enum WeekDay
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }
    }
}
