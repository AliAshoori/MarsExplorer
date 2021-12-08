using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using FluentAssertions;
using MarsExplorer.Commands;
using MarsExplorer.Model;
using MarsExplorer.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsExplorer.Tests
{
    [TestCategory("MarsExplorer.Commands")]
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class RobotInstructionCommandTests
    {
        [TestMethod]
        public void BuildInstructions_WithValidInstructionTypes_ReturnsAllInstances()
        {
            // Arrange
            var mars = MarsPlanet.Instance;
            mars.Coordinates = new MarsCoordinates(6, 6);

            var command = new RobotInstructionCommand(
                new RobotPosition
                {
                    Orientation = Orientation.East,
                    Coordinates = new Coordinates
                    {
                        X = 3,
                        Y = 5
                    }
                },
                "LRFLRF",
                mars);

            // Act
            var instructions = command.BuildInstructions().ToArray();

            // Assert
            instructions.Should().HaveCount(6);
            instructions.OfType<MoveForwardInstructionService>().Should().HaveCount(2);
            instructions.OfType<RotateRightInstructionService>().Should().HaveCount(2);
            instructions.OfType<RotateLeftInstructionService>().Should().HaveCount(2);
        }

        [TestMethod]
        public void BuildInstructions_WithInValidInstructionTypes_ThrowsException()
        {
            // Arrange
            var mars = MarsPlanet.Instance;
            mars.Coordinates = new MarsCoordinates(6, 6);

            var command = new RobotInstructionCommand(
                new RobotPosition
                {
                    Orientation = Orientation.East,
                    Coordinates = new Coordinates
                    {
                        X = 3,
                        Y = 5
                    }
                },
                "LRFLRFX",
                mars);

            // Act
            Action instructions = () => command.BuildInstructions();

            // Assert
            instructions.Should().ThrowExactly<InvalidOperationException>($"Invalid instruction detected: X");
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(null)]
        [DataRow(" ")]
        public void RobotInstructionCommand_WithNoInstructionTypes_ThrowsArgumentNullException(string instructionSeries)
        {
            // Arrange
            var robotPosition = new RobotPosition
            {
                Orientation = Orientation.East,
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
                Orientation = Orientation.East,
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
