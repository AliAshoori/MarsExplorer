using MarsExplorer.Utils;

namespace MarsExplorer.Model
{
    public class Robot
    {
        public Robot(MarsPlanet marsPlanet)
        {
            MarsPlanet = marsPlanet.NotNull();
        }

        public MarsPlanet MarsPlanet { get; }

        public RobotPosition Position { get; set; }

        public bool HasLost { get; set; }

        public void RotateToLeft()
        {
            Position.Orientation = Position.Orientation.GetLeftOrientation();
        }

        public void RotateToRight()
        {
            Position.Orientation = Position.Orientation.GetRightOrientation();
        }

        public void MoveForward()
        {
            if (MarsPlanet.IsPositionScented(Position.Coordinates, Position.Orientation.OrientationType))
            {
                return;
            }

            var targetCoordinates = Position.Orientation.CalculateNextMove(Position.Coordinates);

            if (MarsPlanet.IsDeadZone(targetCoordinates))
            {
                MarsPlanet.ScentSpots.Add(new MarsPlanet.MarsPlanetDeadZone
                {
                    Coordinates = Position.Coordinates,
                    OrientationType = Position.Orientation.OrientationType
                });

                HasLost = true;

                return;
            }

            Position.Coordinates = targetCoordinates; 
        }

        public string GetLatestStatus()
        {
            return HasLost ? $"{Position} LOST" : Position.ToString();
        }
    }
}
