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

        protected RecurringGame() { }

        public RecurringGame(
            string team1Name,
            string team2Name,
            DateTime playingTime,  
            PlayerNumber playerNumber,
            WeekDay weekDay)
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
            Day = weekDay;
        }
        
        public class WeekDay : Enumeration
        {
            public static WeekDay Sunday => new(0, nameof(Sunday));
            public static WeekDay Monday => new(1, nameof(Monday));
            public static WeekDay Tuesday => new(2, nameof(Tuesday));
            public static WeekDay Wednesday => new(3, nameof(Wednesday));
            public static WeekDay Thursday => new(4, nameof(Thursday));
            public static WeekDay Friday => new(5, nameof(Friday));
            public static WeekDay Saturday => new(6, nameof(Saturday));

            public WeekDay(int value, string name) : base(value, name) { }
        }
    }
}
