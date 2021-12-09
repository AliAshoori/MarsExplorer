namespace MarsExplorer.Model
{
    public class WestOrientation : BaseOrientation
    {
        public WestOrientation()
        {
            OrientationType = OrientationType.West;
        }

        public override Coordinates CalculateNextMove(Coordinates currentCoordinates)
        {
            return new() { X = currentCoordinates.X - 1, Y = currentCoordinates.Y };
        }

        public override BaseOrientation GetLeftOrientation()
        {
            return new SouthOrientation();
        }

        public override BaseOrientation GetRightOrientation()
        {
            return new NorthOrientation();
        }
    }
}