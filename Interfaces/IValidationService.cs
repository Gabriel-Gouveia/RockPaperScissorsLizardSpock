using RockPaperScissorsLizardSpock.Enums;

namespace RockPaperScissorsLizardSpock.Interfaces
{
    public interface IValidationService
    {
        Choice Validate(string playerChoice);
    }
}
