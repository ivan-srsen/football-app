using Football.Core.Common;

namespace Football.Core.DomainModels
{
    public class PlayerNumber : Enumeration
    {
        public static PlayerNumber Five = new PlayerNumber(5, nameof(Five));
        public static PlayerNumber Six = new PlayerNumber(6, nameof(Six));
        public static PlayerNumber Seven = new PlayerNumber(7, nameof(Seven));

        public PlayerNumber(int value, string name) 
            : base(value, name)
        { }
    }
}
