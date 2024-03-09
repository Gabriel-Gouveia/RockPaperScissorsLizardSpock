using RockPaperScissorsLizardSpock.Enums;
using RockPaperScissorsLizardSpock.Interfaces;
using RockPaperScissorsLizardSpock.Strategies;

namespace RockPaperScissorsLizardSpock.Handlers
{
    public class SpockScissorsHandler : Handler
    {
        public override IGameStrategy Handle(Choice playerOneChoice, Choice playerTwoChoice)
        {
            if ((playerOneChoice == Choice.SPOCK && playerTwoChoice == Choice.SCISSORS) ||
                (playerOneChoice == Choice.SCISSORS && playerTwoChoice == Choice.SPOCK))
            {
                return new SpockScissorsStrategy();
            }
            else
                return base.Handle(playerOneChoice, playerTwoChoice);
        }
    }
}
