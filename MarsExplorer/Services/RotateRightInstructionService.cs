using MarsExplorer.Model;

namespace MarsExplorer.Services
{
    public class RotateRightInstructionService : BaseInstructionService
    {
        public override void Execute(Robot robot)
        {
            robot.RotateToRight();
        }
    }
}