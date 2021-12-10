using System;

namespace MarsExplorer.Model
{
    public class EastOrientation : BaseOrientation
    {
        private static readonly Lazy<EastOrientation> Lazy = new(() => new EastOrientation());

        public static EastOrientation Instance => Lazy.Value;

        private EastOrientation()
        {
            OrientationType = OrientationType.East;
        }

        public override Coordinates CalculateNextMove(Coordinates currentCoordinates)
        {
            return new() { X = currentCoordinates.X + 1, Y = currentCoordinates.Y };
        }

        public override BaseOrientation GetLeftOrientation()
        {
            return NorthOrientation.Instance;
        }

        public override BaseOrientation GetRightOrientation()
        {
            return SouthOrientation.Instance;
        }
    }
}