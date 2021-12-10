using System;

namespace MarsExplorer.Model
{
    public sealed class WestOrientation : BaseOrientation
    {
        private static readonly Lazy<WestOrientation> Lazy = new(() => new WestOrientation());

        public static WestOrientation Instance => Lazy.Value;

        private WestOrientation()
        {
            OrientationType = OrientationType.West;
        }

        public override Coordinates CalculateNextMove(Coordinates currentCoordinates)
        {
            return new() { X = currentCoordinates.X - 1, Y = currentCoordinates.Y };
        }

        public override BaseOrientation GetLeftOrientation()
        {
            return SouthOrientation.Instance;
        }

        public override BaseOrientation GetRightOrientation()
        {
            return NorthOrientation.Instance;
        }
    }
}