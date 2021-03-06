using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using FluentAssertions;
using MarsExplorer.Commands;
using MarsExplorer.Model;
using MarsExplorer.Services;
using MarsExplorer.Tests.TestData;
using MarsExplorer.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;

namespace MarsExplorer.Tests
{
    [TestCategory("MarsExplorer.CommandHandlers")]
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class RobotInstructionCommandHandlerTests
    {
        [TestMethod]
        public void Handle_VariousCommands_ReturnsLatestRobotStatus()
        {
            // Arrange
            var testData = JsonConvert.DeserializeObject<InstructionsTestData>(File.ReadAllText("TestData\\TestData.json"));
            var commands = new List<RobotInstructionCommand>();
            var instructionResults = new StringBuilder();
            var expected = new StringBuilder();

            var mars = MarsPlanet.Instance;
            mars.Coordinates = new MarsCoordinates(testData.MarsCoordinates.Cols, testData.MarsCoordinates.Rows);

            foreach (var data in testData.Instructions)
            {
                var robotPosition = new RobotPosition
                {
                    Orientation = data.Input.RobotInitialPosition.Orientation.InstantiateOrientation(),
                    Coordinates = new Coordinates
                    {
                        X = data.Input.RobotInitialPosition.X,
                        Y = data.Input.RobotInitialPosition.Y
                    }
                };

                // populate commands
                commands.Add(new RobotInstructionCommand(robotPosition, data.Input.InstructionSeries, mars));

                // populate expected outputs
                expected.AppendLine(data.ExpectedOutput);
            }

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

            var handler = new RobotInstructionCommandHandler(servicesCreator);

            // Act
            commands.ForEach(c => instructionResults.AppendLine(handler.Handle(c)));

            // Assert
            instructionResults.ToString().Should().BeEquivalentTo(expected.ToString());
        }
    }
}