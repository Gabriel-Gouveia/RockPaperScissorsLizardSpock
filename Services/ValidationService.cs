using RockPaperScissorsLizardSpock.Enums;
using RockPaperScissorsLizardSpock.Interfaces;
using System;
using System.Collections.Generic;

namespace RockPaperScissorsLizardSpock.Services
{
    public class ValidationService : IValidationService
    {
        private readonly Dictionary<string, Choice> _choiceMap;

        public ValidationService()
        {
            _choiceMap = new Dictionary<string, Choice>
            {
                {"rock", Choice.ROCK},
                {"paper", Choice.PAPER},
                {"scissors", Choice.SCISSORS},
                {"lizard", Choice.LIZARD},
                {"spock", Choice.SPOCK}
            };
        }

        public Choice Validate(string playerChoice)
        {
            if (_choiceMap.TryGetValue(playerChoice.Trim().ToLower(), out Choice choice))            
                return choice;            
            throw new ArgumentException("Invalid choice");
        }
    }
}
