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
                    Orientation = Orientation.South
                }
            };

            // Act
            robot.RotateToLeft();

            // Assert
            robot.Position.Orientation.Should().Be(Orientation.East);
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
                    Orientation = Orientation.West
                }
            };

            // Act
            robot.RotateToLeft();

            // Assert
            robot.Position.Orientation.Should().Be(Orientation.South);
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
                    Orientation = Orientation.North
                }
            };

            // Act
            robot.RotateToLeft();

            // Assert
            robot.Position.Orientation.Should().Be(Orientation.West);
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
                    Orientation = Orientation.East
                }
            };

            // Act
            robot.RotateToLeft();

            // Assert
            robot.Position.Orientation.Should().Be(Orientation.North);
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
                    Orientation = Orientation.South
                }
            };

            // Act
            robot.RotateToRight();

            // Assert
            robot.Position.Orientation.Should().Be(Orientation.West);
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
                    Orientation = Orientation.West
                }
            };

            // Act
            robot.RotateToRight();

            // Assert
            robot.Position.Orientation.Should().Be(Orientation.North);
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
                    Orientation = Orientation.North
                }
            };

            // Act
            robot.RotateToRight();

            // Assert
            robot.Position.Orientation.Should().Be(Orientation.East);
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
                    Orientation = Orientation.East
                }
            };

            // Act
            robot.RotateToRight();

            // Assert
            robot.Position.Orientation.Should().Be(Orientation.South);
        }

        #endregion

        #region MOVE FORWARD

        [TestMethod]
        public void MoveForward_WithInvalidOrientation_ThrowsException()
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
                    }
                }
            };

            // Act
            Action moveForward = () => robot.MoveForward();

            // Assert
            moveForward.Should().ThrowExactly<InvalidOperationException>($"Invalid Orientation found: {robot.Position.Orientation}");
        }

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
                    Orientation = Orientation.North
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
                    Orientation = Orientation.East
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
                    Orientation = Orientation.South
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
                    Orientation = Orientation.East
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
                    Orientation = Orientation.North
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
                    Orientation = Orientation.North
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
                    Orientation = Orientation.North
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
                    Orientation = Orientation.North
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
                    Orientation = Orientation.North
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
                    Orientation = Orientation.North
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
                    Orientation = Orientation.North
                }
            };

            // Assert
            init.Should().ThrowExactly<ArgumentNullException>(nameof(marsPlanet));
        }

        #endregion
    }
}
