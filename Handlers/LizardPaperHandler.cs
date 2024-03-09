using RockPaperScissorsLizardSpock.Enums;
using RockPaperScissorsLizardSpock.Interfaces;
using RockPaperScissorsLizardSpock.Strategies;

namespace RockPaperScissorsLizardSpock.Handlers
{
    public class LizardPaperHandler : Handler
    {
        public override IGameStrategy Handle(Choice playerOneChoice, Choice playerTwoChoice)
        {
            if ((playerOneChoice == Choice.LIZARD && playerTwoChoice == Choice.PAPER) ||
                (playerOneChoice == Choice.PAPER && playerTwoChoice == Choice.LIZARD))
            {
                return new LizardPaperStrategy();
            }
            else
                return base.Handle(playerOneChoice, playerTwoChoice);
        }
    }
}
