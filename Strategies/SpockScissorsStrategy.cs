using RockPaperScissorsLizardSpock.Enums;
using RockPaperScissorsLizardSpock.Interfaces;

namespace RockPaperScissorsLizardSpock.Strategies
{
    public class SpockScissorsStrategy : IGameStrategy
    {
        public string DefineWinner(Choice playerOneChoice, Choice playerTwoChoice)
        {
            if (playerOneChoice == Choice.SPOCK)
                return "Player one is the winner!";
            else 
                return "Player two is the winner!";
        }
    }
}
