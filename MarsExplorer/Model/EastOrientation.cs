namespace MarsExplorer.Model
{
    public class EastOrientation : BaseOrientation
    {
        public EastOrientation()
        {
            OrientationType = OrientationType.East;
        }

        public override Coordinates CalculateNextMove(Coordinates currentCoordinates)
        {
            return new() { X = currentCoordinates.X + 1, Y = currentCoordinates.Y };
        }

        public override BaseOrientation GetLeftOrientation()
        {
            return new NorthOrientation();
        }

        public override BaseOrientation GetRightOrientation()
        {
            return new SouthOrientation();
        }
    }
}