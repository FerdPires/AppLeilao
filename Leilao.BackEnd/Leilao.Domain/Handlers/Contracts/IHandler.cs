using Leilao.Domain.Commands.Contracts;

namespace Leilao.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
