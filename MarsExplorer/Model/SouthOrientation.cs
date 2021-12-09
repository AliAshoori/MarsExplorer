namespace MarsExplorer.Model
{
    public class SouthOrientation : BaseOrientation
    {
        public SouthOrientation()
        {
            OrientationType = OrientationType.South;
        }

        public override Coordinates CalculateNextMove(Coordinates currentCoordinates)
        {
            return new() { X = currentCoordinates.X, Y = currentCoordinates.Y - 1 };
        }

        public override BaseOrientation GetLeftOrientation()
        {
            return new EastOrientation();
        }

        public override BaseOrientation GetRightOrientation()
        {
            return new WestOrientation();
        }
    }
}