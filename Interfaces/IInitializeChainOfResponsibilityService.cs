using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock.Interfaces
{
    public interface IInitializeChainOfResponsibilityService
    {
        IHandler GetFirstHandler();
    }
}
