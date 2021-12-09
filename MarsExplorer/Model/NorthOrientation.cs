namespace MarsExplorer.Model
{
    public class NorthOrientation : BaseOrientation
    {
        public NorthOrientation()
        {
            OrientationType = OrientationType.North;
        }

        public override Coordinates CalculateNextMove(Coordinates currentCoordinates)
        {
            return new() { X = currentCoordinates.X, Y = currentCoordinates.Y + 1 };
        }

        public override BaseOrientation GetLeftOrientation()
        {
            return new WestOrientation();
        }

        public override BaseOrientation GetRightOrientation()
        {
            return new EastOrientation();
        }
    }
}