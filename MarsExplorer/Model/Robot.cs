using System;
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
            Position.Orientation = Position.Orientation switch
            {
                Orientation.East => Orientation.North,
                Orientation.North => Orientation.West,
                Orientation.West => Orientation.South,
                Orientation.South => Orientation.East,
                _ => throw new InvalidOperationException()
            };
        }

        public void RotateToRight()
        {
            Position.Orientation = Position.Orientation switch
            {
                Orientation.East => Orientation.South,
                Orientation.North => Orientation.East,
                Orientation.West => Orientation.North,
                Orientation.South => Orientation.West,
                _ => throw new InvalidOperationException()
            };
        }

        public void MoveForward()
        {
            var targetCoordinates = Position.Orientation switch
            {
                Orientation.East => new Coordinates { X = Position.Coordinates.X + 1, Y = Position.Coordinates.Y },
                Orientation.North => new Coordinates { X = Position.Coordinates.X, Y = Position.Coordinates.Y + 1 },
                Orientation.South => new Coordinates { X = Position.Coordinates.X, Y = Position.Coordinates.Y - 1 },
                Orientation.West => new Coordinates { X = Position.Coordinates.X - 1, Y = Position.Coordinates.Y },
                _ => throw new InvalidOperationException($"Invalid Orientation found: {Position.Orientation}")
            };

            if (MarsPlanet.IsPositionScented(targetCoordinates))
            {
                return;
            }

            if (MarsPlanet.IsDeadZone(targetCoordinates))
            {
                MarsPlanet.CoordinatesWithScent.Add(Position.Coordinates);
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
