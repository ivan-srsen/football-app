namespace Football.Core.DomainModels
{
    public class Competitor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Position { get; set; }

        public Competitor(string firstName, string lastName, int position)
        {
            FirstName = firstName;
            LastName = lastName;
            Position = position;
        }
    }
}
