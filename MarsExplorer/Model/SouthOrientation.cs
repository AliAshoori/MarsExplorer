using System;

namespace MarsExplorer.Model
{
    public sealed class SouthOrientation : BaseOrientation
    {
        private static readonly Lazy<SouthOrientation> Lazy = new(() => new SouthOrientation());

        public static SouthOrientation Instance => Lazy.Value;

        private SouthOrientation()
        {
            OrientationType = OrientationType.South;
        }

        public override Coordinates CalculateNextMove(Coordinates currentCoordinates)
        {
            return new() { X = currentCoordinates.X, Y = currentCoordinates.Y - 1 };
        }

        public override BaseOrientation GetLeftOrientation()
        {
            return EastOrientation.Instance;
        }

        public override BaseOrientation GetRightOrientation()
        {
            return WestOrientation.Instance;
        }
    }
}