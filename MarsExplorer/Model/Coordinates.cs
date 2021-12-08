namespace MarsExplorer.Model
{
    public class Coordinates
    {
        public int X { get; set; }

        public int Y { get; set; }

        public bool EqualsWith(Coordinates other) => other.X == X && other.Y == Y;
    }
}