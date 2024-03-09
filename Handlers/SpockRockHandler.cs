using RockPaperScissorsLizardSpock.Enums;
using RockPaperScissorsLizardSpock.Interfaces;
using RockPaperScissorsLizardSpock.Strategies;

namespace RockPaperScissorsLizardSpock.Handlers
{
    public class SpockRockHandler : Handler
    {
        public override IGameStrategy Handle(Choice playerOneChoice, Choice playerTwoChoice)
        {
            if ((playerOneChoice == Choice.SPOCK && playerTwoChoice == Choice.ROCK) ||
                (playerOneChoice == Choice.ROCK && playerTwoChoice == Choice.SPOCK))
            {
                return new SpockRockStrategy();
            }
            else
                return base.Handle(playerOneChoice, playerTwoChoice);
        }
    }
}
