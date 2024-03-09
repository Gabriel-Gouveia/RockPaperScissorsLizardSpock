using RockPaperScissorsLizardSpock.Enums;

namespace RockPaperScissorsLizardSpock.Interfaces
{
    public interface IGameStrategy
    {
        string DefineWinner(Choice playerOneChoice, Choice playerTwoChoice);
    }
}
