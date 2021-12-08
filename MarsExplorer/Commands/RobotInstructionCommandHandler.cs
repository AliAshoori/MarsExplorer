using MarsExplorer.Model;

namespace MarsExplorer.Commands
{
    public class RobotInstructionCommandHandler : ICommandHandler<RobotInstructionCommand, string>
    {
        public string Handle(RobotInstructionCommand command)
        {
            var robot = new Robot(command.MarsPlanet) { Position = command.Position };

            foreach (var instruction in command.BuildInstructions())
            {
                if (robot.HasLost) break;

                instruction.Execute(robot);
            }

            return robot.GetLatestStatus();
        }
    }
}