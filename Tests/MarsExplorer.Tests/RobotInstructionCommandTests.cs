using System;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using MarsExplorer.Commands;
using MarsExplorer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsExplorer.Tests
{
    [TestCategory("MarsExplorer.Commands")]
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class RobotInstructionCommandTests
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(null)]
        [DataRow(" ")]
        public void RobotInstructionCommand_WithNoInstructionTypes_ThrowsArgumentNullException(string instructionSeries)
        {
            // Arrange
            var robotPosition = new RobotPosition
            {
                Orientation = EastOrientation.Instance,
                Coordinates = new Coordinates
                {
                    X = 3,
                    Y = 5
                }
            };

            var mars = MarsPlanet.Instance;
            mars.Coordinates = new MarsCoordinates(6, 6);

            // Act
            Action init = () =>
                new RobotInstructionCommand(
                    robotPosition,
                    instructionSeries,
                    mars);

            // Assert
            init.Should().ThrowExactly<ArgumentNullException>(nameof(instructionSeries));
        }

        [TestMethod]
        public void RobotInstructionCommand_WithNoMasterPlanet_ThrowsArgumentNullException()
        {
            // Arrange
            var robotPosition = new RobotPosition
            {
                Orientation = EastOrientation.Instance,
                Coordinates = new Coordinates
                {
                    X = 3,
                    Y = 5
                }
            };

            MarsPlanet marsPlanet = null;

            // Act
            Action init = () =>
                new RobotInstructionCommand(
                    robotPosition,
                    "FLR",
                    marsPlanet);

            // Assert
            init.Should().ThrowExactly<ArgumentNullException>(nameof(marsPlanet));
        }

        [TestMethod]
        public void RobotInstructionCommand_WithNoRobotPosition_ThrowsArgumentNullException()
        {
            // Arrange
            RobotPosition position = null;

            var mars = MarsPlanet.Instance;
            mars.Coordinates = new MarsCoordinates(6, 6);

            // Act
            Action init = () =>
                new RobotInstructionCommand(
                    position,
                    "LFLR",
                    mars);

            // Assert
            init.Should().ThrowExactly<ArgumentNullException>(nameof(position));
        }
    }
}