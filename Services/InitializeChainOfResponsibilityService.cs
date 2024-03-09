using RockPaperScissorsLizardSpock.Handlers;
using RockPaperScissorsLizardSpock.Interfaces;

namespace RockPaperScissorsLizardSpock.Services
{
    public class InitializeChainOfResponsibilityService : IInitializeChainOfResponsibilityService
    {
        private LizardPaperHandler _firstHandler = new LizardPaperHandler();

        public InitializeChainOfResponsibilityService()
        {
            _firstHandler.SetNext(new LizardSpockHandler())
                         .SetNext(new PaperRockHandler())
                         .SetNext(new PaperSpockHandler())
                         .SetNext(new RockLizardHandler())
                         .SetNext(new RockScissorsHandler())
                         .SetNext(new ScissorsLizardHandler())
                         .SetNext(new ScissorsPaperHandler())
                         .SetNext(new SpockRockHandler())
                         .SetNext(new SpockScissorsHandler());
        }

        public IHandler GetFirstHandler()
        {
            return _firstHandler;
        }
    }
}
