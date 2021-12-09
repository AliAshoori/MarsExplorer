using MarsExplorer.Utils;

namespace MarsExplorer.Model
{
    public class RobotPosition
    {
        public BaseOrientation Orientation { get; set; }

        public Coordinates Coordinates { get; set; }

        public override string ToString()
        {
            return $"{Coordinates.X} {Coordinates.Y} {Orientation.OrientationType.GetDisplayName()}";
        }
    }
}