using Microsoft.AspNetCore.Mvc;
using RockPaperScissorsLizardSpock.Enums;
using RockPaperScissorsLizardSpock.Interfaces;
using System;

namespace RockPaperScissorsLizardSpock.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private IValidationService _validationService;
        private IGameContext _gameContext;
        private IInitializeChainOfResponsibilityService _initializeChainOfResponsibilityService;

        public GameController(IValidationService validationService,
                              IGameContext gameContext,
                              IInitializeChainOfResponsibilityService initializeChainOfResponsibilityService)
        {
            _validationService = validationService;
            _initializeChainOfResponsibilityService = initializeChainOfResponsibilityService;
            _gameContext = gameContext;            
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult Play(string playerOneChoice, string playerTwoChoice)
        {
            try
            {
                Choice playerOneValidChoice = _validationService.Validate(playerOneChoice);
                Choice playerTwoValidChoice = _validationService.Validate(playerTwoChoice);
                if (playerOneValidChoice == playerTwoValidChoice)
                    return Ok("Tie");
                IGameStrategy gameStrategy = _initializeChainOfResponsibilityService.GetFirstHandler().Handle(playerOneValidChoice, playerTwoValidChoice);
                _gameContext.SetStrategy(gameStrategy);
                return Ok(_gameContext.DefineWinner(playerOneValidChoice, playerTwoValidChoice));
            }
            catch (ArgumentException argEx)
            {
                return BadRequest(argEx.Message);
            }
            catch (NullReferenceException)
            {
                return BadRequest("Invalid choice");
            }
            catch (Exception)
            {
                return StatusCode(500, "An internal server error has occurred. Please, try again later.");
            }
        }
    }
}
