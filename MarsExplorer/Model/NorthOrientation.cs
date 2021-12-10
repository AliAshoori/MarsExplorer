using System;

namespace MarsExplorer.Model
{
    public sealed class NorthOrientation : BaseOrientation
    {
        private static readonly Lazy<NorthOrientation> Lazy = new(() => new NorthOrientation());

        public static NorthOrientation Instance => Lazy.Value;

        private NorthOrientation()
        {
            OrientationType = OrientationType.North;
        }

        public override Coordinates CalculateNextMove(Coordinates currentCoordinates)
        {
            return new() { X = currentCoordinates.X, Y = currentCoordinates.Y + 1 };
        }

        public override BaseOrientation GetLeftOrientation()
        {
            return WestOrientation.Instance;
        }

        public override BaseOrientation GetRightOrientation()
        {
            return EastOrientation.Instance;
        }
    }
}