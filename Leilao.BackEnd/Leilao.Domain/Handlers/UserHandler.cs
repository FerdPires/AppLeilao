using Flunt.Notifications;
using Leilao.Domain.Commands;
using Leilao.Domain.Commands.Contracts;
using Leilao.Domain.Entities;
using Leilao.Domain.Handlers.Contracts;
using Leilao.Domain.Repositories;

namespace Leilao.Domain.Handlers
{
    public class UserHandler :
        Notifiable,
        IHandler<EnableUserCommand>,
        IHandler<DisableUserCommand>,
        IHandler<CreateUserCommand>
    {
        private readonly IUserRepository _repository;

        public UserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateUserCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Algo deu errado!", command.Notifications);
            }

            var user = new UserAccount
                (
                    command.User
                );

            _repository.Create(user);

            return new GenericCommandResult(true, "O usuário foi criado!", user);
        }

        public ICommandResult Handle(EnableUserCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Algo deu errado!", command.Notifications);
            }

            var user = _repository.GetUser(command.User);

            user.EnableUser(command.User);

            _repository.Update(user);

            return new GenericCommandResult(true, "O usuário foi ativado!", user);
        }

        public ICommandResult Handle(DisableUserCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Algo deu errado!", command.Notifications);
            }

            var user = _repository.GetUser(command.User);

            user.DisableUser(command.User);

            _repository.Update(user);

            return new GenericCommandResult(true, "O usuário foi desativado!", user);
        }

    }
}
