using RockPaperScissorsLizardSpock.Enums;
using RockPaperScissorsLizardSpock.Interfaces;

namespace RockPaperScissorsLizardSpock.Strategies
{
    public class LizardSpockStrategy : IGameStrategy
    {
        public string DefineWinner(Choice playerOneChoice, Choice playerTwoChoice)
        {
            string result = "Lizard poisons Spock.\n";
            if (playerOneChoice == Choice.LIZARD)
                result += "Player one is the winner!";
            else
                result += "Player two is the winner!";
            return result;
        }
    }
}
