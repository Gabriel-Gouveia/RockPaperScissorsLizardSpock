using RockPaperScissorsLizardSpock.Enums;

namespace RockPaperScissorsLizardSpock.Interfaces
{
    public interface IHandler
    {
        IGameStrategy Handle(Choice playerOneChoice, Choice playerTwoChoice);

        IHandler SetNext(IHandler handler);        
    }
}
