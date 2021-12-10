using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsExplorer.Model
{
    public sealed class MarsPlanet
    {
        private MarsPlanet()
        {

        }

        private static readonly Lazy<MarsPlanet> Lazy = new(() => new MarsPlanet());

        public static MarsPlanet Instance => Lazy.Value;

        public IList<MarsPlanetDeadZone> ScentSpots { get; set; } = new List<MarsPlanetDeadZone>();

        public MarsCoordinates Coordinates { get; set; }

        public bool IsDeadZone(Coordinates targetPosition)
        {
            return Coordinates.IsDeadZone(targetPosition);
        }

        public bool IsPositionScented(Coordinates targetCoordinates, OrientationType orientationType)
        {
            return ScentSpots.Any(spot => spot.Coordinates.EqualsWith(targetCoordinates) &&
                                          spot.OrientationType == orientationType);
        }

        public class MarsPlanetDeadZone
        {
            public OrientationType OrientationType { get; set; }

            public Coordinates Coordinates { get; set; }
        }
    }
}