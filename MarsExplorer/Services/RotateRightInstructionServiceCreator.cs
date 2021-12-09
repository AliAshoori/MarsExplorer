using System;
using MarsExplorer.Commands;

namespace MarsExplorer.Services
{
    public class RotateRightInstructionServiceCreator : IInstructionServiceCreator
    {
        public bool IsMatch(string instruction)
        {
            return string.Compare(instruction, InstructionTypeConstants.RIGHT, StringComparison.OrdinalIgnoreCase) == 0;
        }

        public BaseInstructionService Create()
        {
            return new RotateRightInstructionService();
        }
    }
}