using MarsExplorer.Model;
using MarsExplorer.Services;
using MarsExplorer.Utils;

namespace MarsExplorer.Commands
{
    public class RobotInstructionCommandHandler : ICommandHandler<RobotInstructionCommand, string>
    {
        private readonly IInstructionServicesCreator _instructionServicesCreator;

        public RobotInstructionCommandHandler(IInstructionServicesCreator instructionServicesCreator)
        {
            _instructionServicesCreator = instructionServicesCreator.NotNull();
        }

        public string Handle(RobotInstructionCommand command)
        {
            var robot = new Robot(command.MarsPlanet) { Position = command.Position };

            var instructions = _instructionServicesCreator.CreateFromCommands(command.InstructionSeries);
            
            foreach (var instruction in instructions)
            {
                if (robot.HasLost) break;

                instruction.Execute(robot);
            }

            return robot.GetLatestStatus();
        }
    }
}