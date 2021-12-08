using MarsExplorer.Model;

namespace MarsExplorer.Services
{
    public class RotateLeftInstructionService : BaseInstructionService
    {
        public override void Execute(Robot robot)
        {
            robot.RotateToLeft();
        }
    }
}