using System.Collections.Generic;
using System.Linq;
using MarsExplorer.Utils;

namespace MarsExplorer.Model
{
    public class MarsPlanet
    {
        public MarsPlanet(MarsCoordinates coordinates)
        {
            Coordinates = coordinates.NotNull();
            CoordinatesWithScent = new List<Coordinates>();
        }

        public IList<Coordinates> CoordinatesWithScent { get; set; }

        public MarsCoordinates Coordinates { get; }
        
        public bool IsDeadZone(Coordinates targetPosition)
        {
            return Coordinates.IsDeadZone(targetPosition);
        }

        public bool IsPositionScented(Coordinates targetCoordinates)
        {
            return CoordinatesWithScent.Any((pos => pos.EqualsWith(targetCoordinates)));
        }
    }
}