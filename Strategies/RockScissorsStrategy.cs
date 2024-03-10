using RockPaperScissorsLizardSpock.Enums;
using RockPaperScissorsLizardSpock.Interfaces;

namespace RockPaperScissorsLizardSpock.Strategies
{
    public class RockScissorsStrategy : IGameStrategy
    {
        public string DefineWinner(Choice playerOneChoice, Choice playerTwoChoice)
        {
            string result = "Rock smashes scissors.\n";
            if (playerOneChoice == Choice.ROCK)
                result += "Player one is the winner!";
            else 
                result += "Player two is the winner!";
            return result;
        }
    }
}
