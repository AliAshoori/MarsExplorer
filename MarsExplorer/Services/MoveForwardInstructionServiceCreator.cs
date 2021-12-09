using System;
using MarsExplorer.Commands;

namespace MarsExplorer.Services
{
    public class MoveForwardInstructionServiceCreator : IInstructionServiceCreator
    {
        public bool IsMatch(string instruction)
        {
            return string.Compare(instruction, InstructionTypeConstants.FORWARD, StringComparison.OrdinalIgnoreCase) == 0;
        }

        public BaseInstructionService Create()
        {
            return new MoveForwardInstructionService();
        }
    }
}