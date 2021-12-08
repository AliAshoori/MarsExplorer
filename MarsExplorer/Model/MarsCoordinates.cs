namespace MarsExplorer.Model
{
    public class MarsCoordinates
    {
        public MarsCoordinates(int numberOfColumns, int numberOfRows)
        {
            NumberOfRows = numberOfRows;
            NumberOfColumns = numberOfColumns;
        }

        public int NumberOfRows { get; }

        public int NumberOfColumns { get; }

        public bool IsDeadZone(Coordinates targetPosition)
        {
            return NumberOfRows < targetPosition.Y || 
                   NumberOfColumns < targetPosition.X;
        }
    }
}