using RockPaperScissorsLizardSpock.Enums;
using RockPaperScissorsLizardSpock.Interfaces;

namespace RockPaperScissorsLizardSpock.Strategies
{
    public class LizardPaperStrategy : IGameStrategy
    {
        public string DefineWinner(Choice playerOneChoice, Choice playerTwoChoice)
        {
            string result = "Lizard eats paper.\n";
            if (playerOneChoice == Choice.LIZARD)
                result += "Player one is the winner!";
            else
                result += "Player two is the winner!";
            return result;
        }
    }
}
