using Football.Core.DomainModels;
using MediatR;

namespace Football.Core.Events
{
    public class GameCreatedDomainEvent : INotification
    {
        public Game Game { get; private set; }

        public GameCreatedDomainEvent(Game game)
        {
            Game = game;
        }
    }
}
