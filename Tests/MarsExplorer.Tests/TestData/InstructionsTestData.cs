using System.Collections.Generic;
using Newtonsoft.Json;

namespace MarsExplorer.Tests.TestData
{
    public class InstructionsTestData
    {
        [JsonProperty("coordinates")]
        public MarsCoordinatesTest MarsCoordinates { get; set; }

        [JsonProperty("instructions")]
        public List<InstructionTest> Instructions { get; set; }

        public class MarsCoordinatesTest
        {
            [JsonProperty("cols")]
            public int Cols { get; set; }

            [JsonProperty("rows")]
            public int Rows { get; set; }
        }

        public class RobotInitialPosition
        {
            [JsonProperty("X")]
            public int X { get; set; }

            [JsonProperty("Y")]
            public int Y { get; set; }

            [JsonProperty("orientation")]
            public string Orientation { get; set; }
        }

        public class Input
        {
            [JsonProperty("robotInitialPosition")]
            public RobotInitialPosition RobotInitialPosition { get; set; }

            [JsonProperty("commands")]
            public string InstructionSeries { get; set; }
        }

        public class RobotInitialPositionTest
        {
            [JsonProperty("X")]
            public int X { get; set; }

            [JsonProperty("Y")]
            public int Y { get; set; }

            [JsonProperty("orientation")]
            public string Orientation { get; set; }
        }

        public class InstructionTest
        {
            [JsonProperty("input")]
            public Input Input { get; set; }

            [JsonProperty("expectedOutput")]
            public string ExpectedOutput { get; set; }
        }
    }
}
