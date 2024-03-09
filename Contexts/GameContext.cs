using RockPaperScissorsLizardSpock.Enums;
using RockPaperScissorsLizardSpock.Interfaces;

namespace RockPaperScissorsLizardSpock.Contexts
{
    public class GameContext : IGameContext
    {
        private IGameStrategy _strategy;

        public GameContext() { }

        public GameContext(IGameStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(IGameStrategy strategy)
        {
            _strategy = strategy;
        }

        public string DefineWinner(Choice playerOneChoice, Choice playerTwoChoice)
        {
            return _strategy.DefineWinner(playerOneChoice, playerTwoChoice);
        }
    }
}
