using RockPaperScissorsLizardSpock.Enums;
using RockPaperScissorsLizardSpock.Interfaces;
using RockPaperScissorsLizardSpock.Strategies;

namespace RockPaperScissorsLizardSpock.Handlers
{
    public class ScissorsLizardHandler : Handler
    {
        public override IGameStrategy Handle(Choice playerOneChoice, Choice playerTwoChoice)
        {
            if ((playerOneChoice == Choice.SCISSORS && playerTwoChoice == Choice.LIZARD) ||
                (playerOneChoice == Choice.LIZARD && playerTwoChoice == Choice.SCISSORS))
            {
                return new ScissorsLizardStrategy();
            }
            else
                return base.Handle(playerOneChoice, playerTwoChoice);
        }
    }
}
