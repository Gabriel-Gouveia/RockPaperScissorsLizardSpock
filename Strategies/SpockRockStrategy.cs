using RockPaperScissorsLizardSpock.Enums;
using RockPaperScissorsLizardSpock.Interfaces;

namespace RockPaperScissorsLizardSpock.Strategies
{
    public class SpockRockStrategy : IGameStrategy
    {
        public string DefineWinner(Choice playerOneChoice, Choice playerTwoChoice)
        {
            string result = "Spock vaporizes rock.\n";
            if (playerOneChoice == Choice.SPOCK)
                result += "Player one is the winner!";
            else 
                result += "Player two is the winner!";
            return result;
        }
    }
}
