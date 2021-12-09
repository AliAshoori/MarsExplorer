using System.Collections.Generic;

namespace MarsExplorer.Services
{
    public interface IInstructionServicesCreator
    {
        IEnumerable<BaseInstructionService> CreateFromCommands(string commands);
    }
}