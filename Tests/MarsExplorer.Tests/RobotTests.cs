using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using MarsExplorer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsExplorer.Tests
{
    [TestCategory("MarsExplorer.Models")]
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class RobotTests
    {
        #region ROTATE TO LEFT

        [TestMethod]
        public void RotateToLeft_FromSouthOrientation_ReturnsEast()
        {
            // Arrange
            var mars = MarsPlanet.Instance;
            mars.Coordinates = new MarsCoordinates(4, 4);

            var robot = new Robot(mars)
            {
                Position = new RobotPosition
                {
                    Coordinates = new Coordinates
                    {
                        X = 1,
                        Y = 1
                    },
                    Orientation = SouthOrientation.Instance
                }
            };

            // Act
            robot.RotateToLeft();

            // Assert
            robot.Position.Orientation.OrientationType.Should().Be(OrientationType.East);
        }

        [TestMethod]
        public void RotateToLeft_FromWestOrientation_ReturnsSouth()
        {
            // Arrange
            var mars = MarsPlanet.Instance;
            mars.Coordinates = new MarsCoordinates(4, 4);

            var robot = new Robot(mars)
            {
                Position = new RobotPosition
                {
                    Coordinates = new Coordinates
                    {
                        X = 1,
                        Y = 1
                    },
                    Orientation = WestOrientation.Instance
                }
            };

            // Act
            robot.RotateToLeft();

            // Assert
            robot.Position.Orientation.OrientationType.Should().Be(OrientationType.South);
        }

        [TestMethod]
        public void RotateToLeft_FromNorthOrientation_ReturnsWest()
        {
            // Arrange
            var mars = MarsPlanet.Instance;
            mars.Coordinates = new MarsCoordinates(4, 4);

            var robot = new Robot(mars)
            {
                Position = new RobotPosition
                {
                    Coordinates = new Coordinates
                    {
                        X = 1,
                        Y = 1
                    },
                    Orientation = NorthOrientation.Instance
                }
            };

            // Act
            robot.RotateToLeft();

            // Assert
            robot.Position.Orientation.OrientationType.Should().Be(OrientationType.West);
        }

        [TestMethod]
        public void RotateToLeft_FromEastOrientation_ReturnsNorth()
        {
            // Arrange
            var mars = MarsPlanet.Instance;
            mars.Coordinates = new MarsCoordinates(4, 4);

            var robot = new Robot(mars)
            {
                Position = new RobotPosition
                {
                    Coordinates = new Coordinates
                    {
                        X = 1,
                        Y = 1
                    },
                    Orientation = EastOrientation.Instance
                }
            };

            // Act
            robot.RotateToLeft();

            // Assert
            robot.Position.Orientation.OrientationType.Should().Be(OrientationType.North);
        }

        #endregion

        #region ROTATE TO RIGHT

        [TestMethod]
        public void RotateToRight_FromSouthOrientation_ReturnsWest()
        {
            // Arrange
            var mars = MarsPlanet.Instance;
            mars.Coordinates = new MarsCoordinates(4, 4);

            var robot = new Robot(mars)
            {
                Position = new RobotPosition
                {
                    Coordinates = new Coordinates
                    {
                        X = 1,
                        Y = 1
                    },
                    Orientation = SouthOrientation.Instance
                }
            };

            // Act
            robot.RotateToRight();

            // Assert
            robot.Position.Orientation.OrientationType.Should().Be(OrientationType.West);
        }

        [TestMethod]
        public void RotateToRight_FromWestOrientation_ReturnsNorth()
        {
            // Arrange
            var mars = MarsPlanet.Instance;
            mars.Coordinates = new MarsCoordinates(4, 4);

            var robot = new Robot(mars)
            {
                Position = new RobotPosition
                {
                    Coordinates = new Coordinates
                    {
                        X = 1,
                        Y = 1
                    },
                    Orientation = WestOrientation.Instance
                }
            };

            // Act
            robot.RotateToRight();

            // Assert
            robot.Position.Orientation.OrientationType.Should().Be(OrientationType.North);
        }

        [TestMethod]
        public void RotateToRight_FromNorthOrientation_ReturnsEast()
        {
            // Arrange
            var mars = MarsPlanet.Instance;
            mars.Coordinates = new MarsCoordinates(4, 4);

            var robot = new Robot(mars)
            {
                Position = new RobotPosition
                {
                    Coordinates = new Coordinates
                    {
                        X = 1,
                        Y = 1
                    },
                    Orientation = NorthOrientation.Instance
                }
            };

            // Act
            robot.RotateToRight();

            // Assert
            robot.Position.Orientation.OrientationType.Should().Be(OrientationType.East);
        }

        [TestMethod]
        public void RotateToRight_FromEastOrientation_ReturnsSouth()
        {
            // Arrange
            var mars = MarsPlanet.Instance;
            mars.Coordinates = new MarsCoordinates(4, 4);

            var robot = new Robot(mars)
            {
                Position = new RobotPosition
                {
                    Coordinates = new Coordinates
                    {
                        X = 1,
                        Y = 1
                    },
                    Orientation = EastOrientation.Instance
                }
            };

            // Act
            robot.RotateToRight();

            // Assert
            robot.Position.Orientation.OrientationType.Should().Be(OrientationType.South);
        }

        #endregion

        #region MOVE FORWARD

        [TestMethod]
        public void MoveForward_WithNorthOrientation_MovesTowardsNorth()
        {
            // Arrange
            var mars = MarsPlanet.Instance;
            mars.Coordinates = new MarsCoordinates(4, 4);

            var robot = new Robot(mars)
            {
                Position = new RobotPosition
                {
                    Coordinates = new Coordinates
                    {
                        X = 1,
                        Y = 1
                    },
                    Orientation = NorthOrientation.Instance
                }
            };

            var expectedCoordinates = new Coordinates
            {
                X = robot.Position.Coordinates.X,
                Y = robot.Position.Coordinates.Y + 1
            };

            // Act
            robot.MoveForward();

            // Assert
            robot.Position.Coordinates.Should().BeEquivalentTo(expectedCoordinates);
        }

        [TestMethod]
        public void MoveForward_WithEastOrientation_MovesTowardsEast()
        {
            // Arrange
            var mars = MarsPlanet.Instance;
            mars.Coordinates = new MarsCoordinates(4, 4);

            var robot = new Robot(mars)
            {
                Position = new RobotPosition
                {
                    Coordinates = new Coordinates
                    {
                        X = 1,
                        Y = 1
                    },
                    Orientation = EastOrientation.Instance
                }
            };

            var expectedCoordinates = new Coordinates
            {
                X = robot.Position.Coordinates.X + 1,
                Y = robot.Position.Coordinates.Y
            };

            // Act
            robot.MoveForward();

            // Assert
            robot.Position.Coordinates.Should().BeEquivalentTo(expectedCoordinates);
        }

        [TestMethod]
        public void MoveForward_WithSouthOrientation_MovesTowardsSouth()
        {
            // Arrange
            var mars = MarsPlanet.Instance;
            mars.Coordinates = new MarsCoordinates(4, 4);

            var robot = new Robot(mars)
            {
                Position = new RobotPosition
                {
                    Coordinates = new Coordinates
                    {
                        X = 1,
                        Y = 1
                    },
                    Orientation = SouthOrientation.Instance
                }
            };

            var expectedCoordinates = new Coordinates
            {
                X = robot.Position.Coordinates.X,
                Y = robot.Position.Coordinates.Y - 1
            };

            // Act
            robot.MoveForward();

            // Assert
            robot.Position.Coordinates.Should().BeEquivalentTo(expectedCoordinates);
        }

        [TestMethod]
        public void MoveForward_WithEastOrientation_MovesTowardsSouthEast()
        {
            // Arrange
            var mars = MarsPlanet.Instance;
            mars.Coordinates = new MarsCoordinates(4, 4);

            var robot = new Robot(mars)
            {
                Position = new RobotPosition
                {
                    Coordinates = new Coordinates
                    {
                        X = 1,
                        Y = 1
                    },
                    Orientation = EastOrientation.Instance
                }
            };

            var expectedCoordinates = new Coordinates
            {
                X = robot.Position.Coordinates.X + 1,
                Y = robot.Position.Coordinates.Y
            };

            // Act
            robot.MoveForward();

            // Assert
            robot.Position.Coordinates.Should().BeEquivalentTo(expectedCoordinates);
        }

        [TestMethod]
        public void MoveForward_TargetsScentedPosition_DoesNotMove()
        {
            // Arrange
            var mars = MarsPlanet.Instance;
            mars.Coordinates = new MarsCoordinates(4, 4);
            mars.ScentSpots = new List<MarsPlanet.MarsPlanetDeadZone>
            {
                new()
                {
                    Coordinates = new Coordinates
                    {
                        X = 3,
                        Y = 4
                    },
                    OrientationType = OrientationType.North
                }
            };

            var robot = new Robot(mars)
            {
                Position = new RobotPosition
                {
                    Coordinates = new Coordinates
                    {
                        X = 3,
                        Y = 4
                    },
                    Orientation = NorthOrientation.Instance
                }
            };

            var expectedCoordinates = new Coordinates
            {
                X = 3,
                Y = 4
            };

            // Act
            robot.MoveForward();

            // Assert
            robot.Position.Coordinates.Should().BeEquivalentTo(expectedCoordinates);
        }

        #endregion

        #region GET LATESAT STATUS

        [TestMethod]
        public void GetLatestStatus_WithLostRobot_ReturnsLost()
        {
            // Arrange
            var mars = MarsPlanet.Instance;
            mars.Coordinates = new MarsCoordinates(4, 4);
            mars.ScentSpots = new List<MarsPlanet.MarsPlanetDeadZone>
            {
                new()
                {
                    Coordinates = new Coordinates
                    {
                        X = 3,
                        Y = 4
                    },
                    OrientationType = OrientationType.North
                }
            };

            var robot = new Robot(mars)
            {
                Position = new RobotPosition
                {
                    Coordinates = new Coordinates
                    {
                        X = 4,
                        Y = 4
                    },
                    Orientation = NorthOrientation.Instance
                },
                HasLost = true
            };

            var expected = $"{robot.Position} LOST";

            // Act
            var latestStatus = robot.GetLatestStatus();

            // Assert
            latestStatus.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void GetLatestStatus_WithActiveRobot_ReturnsPosition()
        {
            // Arrange
            var mars = MarsPlanet.Instance;
            mars.Coordinates = new MarsCoordinates(4, 4);
            mars.ScentSpots = new List<MarsPlanet.MarsPlanetDeadZone>
            {
                new()
                {
                    Coordinates = new Coordinates
                    {
                        X = 3,
                        Y = 4
                    },
                    OrientationType = OrientationType.North
                }
            };

            var robot = new Robot(mars)
            {
                Position = new RobotPosition
                {
                    Coordinates = new Coordinates
                    {
                        X = 1,
                        Y = 1
                    },
                    Orientation = NorthOrientation.Instance
                }
            };

            var expected = $"{robot.Position}";

            // Act
            var latestStatus = robot.GetLatestStatus();

            // Assert
            latestStatus.Should().BeEquivalentTo(expected);
        }

        #endregion

        #region CONSTRUCTORS

        [TestMethod]
        public void Robot_WithNullMarsClient_ThrowsArgumentNullException()
        {
            // Arrange
            MarsPlanet marsPlanet = null;

            // Act
            Action init = () => new Robot(marsPlanet)
            {
                Position = new RobotPosition
                {
                    Coordinates = new Coordinates
                    {
                        X = 4,
                        Y = 4
                    },
                    Orientation = NorthOrientation.Instance
                }
            };

            // Assert
            init.Should().ThrowExactly<ArgumentNullException>(nameof(marsPlanet));
        }

        #endregion
    }
}
