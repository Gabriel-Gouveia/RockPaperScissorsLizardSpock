using RockPaperScissorsLizardSpock.Enums;
using RockPaperScissorsLizardSpock.Interfaces;

namespace RockPaperScissorsLizardSpock.Handlers
{
    public abstract class Handler : IHandler
    {
        private IHandler _nextHandler;
        public virtual IGameStrategy Handle(Choice playerOneChoice, Choice playerTwoChoice)
        {
            if (_nextHandler != null)
                return _nextHandler.Handle(playerOneChoice, playerTwoChoice);
            else
                return null;
        }

        public IHandler SetNext(IHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }
    }
}
