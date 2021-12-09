namespace MarsExplorer.Services
{
    public interface IInstructionServiceCreator
    {
        bool IsMatch(string instruction);

        BaseInstructionService Create();
    }
}