using RockPaperScissorsLizardSpock.Enums;
using RockPaperScissorsLizardSpock.Interfaces;

namespace RockPaperScissorsLizardSpock.Strategies
{
    public class LizardSpockStrategy : IGameStrategy
    {
        public string DefineWinner(Choice playerOneChoice, Choice playerTwoChoice)
        {
            if (playerOneChoice == Choice.LIZARD)
                return "Player one is the winner!";
            else
                return "Player two is the winner!";
        }
    }
}
