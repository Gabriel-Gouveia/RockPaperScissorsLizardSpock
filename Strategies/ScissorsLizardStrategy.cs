using RockPaperScissorsLizardSpock.Enums;
using RockPaperScissorsLizardSpock.Interfaces;

namespace RockPaperScissorsLizardSpock.Strategies
{
    public class ScissorsLizardStrategy : IGameStrategy
    {
        public string DefineWinner(Choice playerOneChoice, Choice playerTwoChoice)
        {
            string result = "Scissors behead lizard.\n";
            if (playerOneChoice == Choice.SCISSORS)
                result += "Player one is the winner!";
            else 
                result += "Player two is the winner!";
            return result;
        }
    }
}
