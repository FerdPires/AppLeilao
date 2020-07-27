using Flunt.Notifications;
using Leilao.Domain.Commands;
using Leilao.Domain.Commands.Contracts;
using Leilao.Domain.Entities;
using Leilao.Domain.Handlers.Contracts;
using Leilao.Domain.Repositories;

namespace Leilao.Domain.Handlers
{
    public class LeilaoHandler :
        Notifiable,
        IHandler<CreateLeilaoCommand>,
        IHandler<UpdateLeilaoCommand>,
        IHandler<DeleteLeilaoCommand>
    {
        private readonly ILeilaoRepository _repository;

        public LeilaoHandler(ILeilaoRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(CreateLeilaoCommand command)
        {
            // Fail Fast Validation(o comando chegou falho ele já barra e avisa)
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Algo deu errado ao incluir!", command.Notifications);
            }

            var leilao = new ItemLeilao
                (
                    command.nome_leilao,
                    command.valor_inicial,
                    command.item_usado,
                    command.data_inicio,
                    command.data_fim,
                    command.nome_usuario,
                    command.User
                );

            _repository.Create(leilao);

            return new GenericCommandResult(true, "Leilão salvo!", leilao);

        }

        public ICommandResult Handle(UpdateLeilaoCommand command)
        {
            // Fail Fast Validation(o comando chegou falho ele já barra e avisa)
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Algo deu errado ao editar!", command.Notifications);
            }

            var leilao = _repository.GetById(command.Id, command.User);

            leilao.UpdateLeilao
                (
                    command.nome_leilao,
                    command.valor_inicial,
                    command.item_usado,
                    command.data_inicio,
                    command.data_fim
                );

            _repository.Update(leilao);

            return new GenericCommandResult(true, "Leilão salvo!", leilao);

        }

        public ICommandResult Handle(DeleteLeilaoCommand command)
        {
            // Fail Fast Validation(o comando chegou falho ele já barra e avisa)
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Algo deu errado ao excluir!", command.Notifications);
            }

            var leilao = _repository.GetById(command.Id, command.User);

            _repository.Delete(leilao);

            return new GenericCommandResult(true, "Leilão excluído!", leilao);
        }
    }
}