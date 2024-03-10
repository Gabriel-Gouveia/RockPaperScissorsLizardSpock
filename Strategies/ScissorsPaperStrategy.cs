using RockPaperScissorsLizardSpock.Enums;
using RockPaperScissorsLizardSpock.Interfaces;

namespace RockPaperScissorsLizardSpock.Strategies
{
    public class ScissorsPaperStrategy : IGameStrategy
    {
        public string DefineWinner(Choice playerOneChoice, Choice playerTwoChoice)
        {
            string result = "Scissors cuts paper.\n";
            if (playerOneChoice == Choice.SCISSORS)
                result += "Player one is the winner!";
            else 
                result += "Player two is the winner!";
            return result;
        }
    }
}
