using System;
using System.Collections.Generic;
using System.Linq;
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
    }

    
}