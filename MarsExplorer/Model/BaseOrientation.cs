namespace MarsExplorer.Model
{
    public abstract class BaseOrientation
    {
        public OrientationType OrientationType { get; set; }

        public abstract Coordinates CalculateNextMove(Coordinates currentCoordinates);

        public abstract BaseOrientation GetLeftOrientation();

        public abstract BaseOrientation GetRightOrientation();
    }
}