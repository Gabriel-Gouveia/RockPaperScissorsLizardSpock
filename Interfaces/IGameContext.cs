using RockPaperScissorsLizardSpock.Enums;

namespace RockPaperScissorsLizardSpock.Interfaces
{
    public interface IGameContext
    {
        string DefineWinner(Choice playerOneChoice, Choice playerTwoChoice);
        void SetStrategy(IGameStrategy strategy);
    }
}
