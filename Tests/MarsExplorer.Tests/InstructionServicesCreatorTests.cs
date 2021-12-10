using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using FluentAssertions;
using MarsExplorer.Commands;
using MarsExplorer.Model;
using MarsExplorer.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MarsExplorer.Tests
{
    [TestCategory("MarsExplorer.Services")]
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class InstructionServicesCreatorTests
    {
        [TestMethod]
        public void Create_WithValidInstructionTypes_ReturnsAllInstances()
        {
            // Arrange
            var mars = MarsPlanet.Instance;
            mars.Coordinates = new MarsCoordinates(6, 6);

            var command = new RobotInstructionCommand(
                new RobotPosition
                {
                    Orientation = EastOrientation.Instance,
                    Coordinates = new Coordinates
                    {
                        X = 3,
                        Y = 5
                    }
                },
                "LRFLRF",
                mars);

            var mockMoveForwardInstruction = new Mock<IInstructionServiceCreator>();
            mockMoveForwardInstruction.Setup(m => m.IsMatch("F")).Returns(true);
            mockMoveForwardInstruction.Setup(m => m.Create()).Returns(new MoveForwardInstructionService());

            var mockRotateLeftInstruction = new Mock<IInstructionServiceCreator>();
            mockRotateLeftInstruction.Setup(m => m.IsMatch("L")).Returns(true);
            mockRotateLeftInstruction.Setup(m => m.Create()).Returns(new RotateLeftInstructionService());

            var mockRotateRightInstruction = new Mock<IInstructionServiceCreator>();
            mockRotateRightInstruction.Setup(m => m.IsMatch("R")).Returns(true);
            mockRotateRightInstruction.Setup(m => m.Create()).Returns(new RotateRightInstructionService());

            var instructionCreators = new[]
            {
                mockMoveForwardInstruction.Object,
                mockRotateRightInstruction.Object,
                mockRotateLeftInstruction.Object
            };

            var servicesCreator = new InstructionServicesCreator(instructionCreators);

            // Act
            var instructions = servicesCreator.CreateFromCommands(command.InstructionSeries).ToArray();

            // Assert
            instructions.Should().HaveCount(6);
            instructions.OfType<MoveForwardInstructionService>().Should().HaveCount(2);
            instructions.OfType<RotateRightInstructionService>().Should().HaveCount(2);
            instructions.OfType<RotateLeftInstructionService>().Should().HaveCount(2);
        }

        [TestMethod]
        public void InstructionServicesCreator_WithNullArg_ThrowsArgNullException()
        {
            // Arrange
            IEnumerable<IInstructionServiceCreator> serviceCreators = null;

            // Act
            Action init = () => new InstructionServicesCreator(serviceCreators);

            // Assert
            init.Should().ThrowExactly<ArgumentNullException>(nameof(serviceCreators));
        }
    }
}
