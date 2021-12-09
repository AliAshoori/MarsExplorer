using System;
using MarsExplorer.Commands;

namespace MarsExplorer.Services
{
    public class RotateLeftInstructionServiceCreator : IInstructionServiceCreator
    {
        public bool IsMatch(string instruction)
        {
            return string.Compare(instruction, InstructionTypeConstants.LEFT, StringComparison.OrdinalIgnoreCase) == 0;
        }

        public BaseInstructionService Create()
        {
            return new RotateLeftInstructionService();
        }
    }
}