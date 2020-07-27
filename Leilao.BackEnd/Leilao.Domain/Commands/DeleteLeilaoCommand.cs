using Flunt.Notifications;
using Flunt.Validations;
using Leilao.Domain.Commands.Contracts;

namespace Leilao.Domain.Commands
{
    public class DeleteLeilaoCommand : Notifiable, ICommand
    {
        public DeleteLeilaoCommand() { }

        public DeleteLeilaoCommand(long id, string user)
        {
            Id = id;
            User = user;
        }

        public long Id { get; set; }
        public string User { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNull(Id, "Id do leilão", "O Id do leilão está vazio!")
                    .IsNotNullOrEmpty(User, "Usuário", "O usuário está vazio!")
            );
        }
    }
}