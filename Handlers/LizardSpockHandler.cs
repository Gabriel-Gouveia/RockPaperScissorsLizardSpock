using RockPaperScissorsLizardSpock.Enums;
using RockPaperScissorsLizardSpock.Interfaces;
using RockPaperScissorsLizardSpock.Strategies;

namespace RockPaperScissorsLizardSpock.Handlers
{
    public class LizardSpockHandler : Handler
    {
        public override IGameStrategy Handle(Choice playerOneChoice, Choice playerTwoChoice)
        {
            if ((playerOneChoice == Choice.LIZARD && playerTwoChoice == Choice.SPOCK) ||
                (playerOneChoice == Choice.SPOCK && playerTwoChoice == Choice.LIZARD))
            {
                return new LizardSpockStrategy();
            }
            else
                return base.Handle(playerOneChoice, playerTwoChoice);
        }
    }
}
