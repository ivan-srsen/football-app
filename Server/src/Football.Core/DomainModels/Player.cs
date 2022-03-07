using Football.Core.Common;

namespace Football.Core.DomainModels
{
    public class Player : AggregateRoot<int>
    {
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public Guid? UserId { get; protected set; }
        public int Position { get; protected set; }

        public Player(string firstName, string lastName, int position, Guid? userId = null)
        {
            FirstName = firstName;
            LastName = lastName;
            Position = position;
            UserId = userId;
        }
    }
}
