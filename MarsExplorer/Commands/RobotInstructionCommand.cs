using System;
using System.Collections.Generic;
using MarsExplorer.Model;
using MarsExplorer.Services;
using MarsExplorer.Utils;

namespace MarsExplorer.Commands
{
    public class RobotInstructionCommand : ICommand<string>
    {
        public RobotInstructionCommand(
            RobotPosition position,
            string instructionSeries,
            MarsPlanet marsPlanet)
        {
            Position = position.NotNull();
            InstructionSeries = instructionSeries.NotNullOrWhiteSpace();
            MarsPlanet = marsPlanet.NotNull();
        }

        public RobotPosition Position { get; }

        public MarsPlanet MarsPlanet { get; }

        public string InstructionSeries { get; }


        public IEnumerable<BaseInstructionService> BuildInstructions()
        {
            var instructions = new List<BaseInstructionService>();

            foreach (var singleInstruction in InstructionSeries)
            {
                switch (singleInstruction)
                {
                    case InstructionTypeConstants.LEFT:
                        instructions.Add(new RotateLeftInstructionService());
                        break;
                    case InstructionTypeConstants.RIGHT:
                        instructions.Add(new RotateRightInstructionService());
                        break;
                    case InstructionTypeConstants.FORWARD:
                        instructions.Add(new MoveForwardInstructionService());
                        break;
                    default:
                        throw new InvalidOperationException($"Invalid instruction detected: {singleInstruction}");
                }
            }

            return instructions;
        }
    }
}