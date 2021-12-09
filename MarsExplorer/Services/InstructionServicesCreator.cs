using System.Collections.Generic;
using System.Linq;
using MarsExplorer.Utils;

namespace MarsExplorer.Services
{
    public class InstructionServicesCreator : IInstructionServicesCreator
    {
        private readonly IEnumerable<IInstructionServiceCreator> _serviceCreators;

        public InstructionServicesCreator(IEnumerable<IInstructionServiceCreator> serviceCreators)
        {
            _serviceCreators = serviceCreators.NotNull();
        }

        public IEnumerable<BaseInstructionService> CreateFromCommands(string commands)
        {
            // it's fine let rai throw exception if not found
            return commands.Select(cmd => _serviceCreators.Single(s => s.IsMatch(cmd.ToString())).Create());
        }
    }
}