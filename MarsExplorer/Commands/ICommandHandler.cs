namespace MarsExplorer.Commands
{
    public interface ICommandHandler<in TCommand, out TResponse> where TCommand : ICommand<TResponse>
    {
        TResponse Handle(TCommand command);
    }
}