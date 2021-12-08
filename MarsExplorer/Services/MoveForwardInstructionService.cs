using MarsExplorer.Model;

namespace MarsExplorer.Services
{
    public class MoveForwardInstructionService : BaseInstructionService
    {
        public override void Execute(Robot robot)
        {
            robot.MoveForward();
        }
    }
}