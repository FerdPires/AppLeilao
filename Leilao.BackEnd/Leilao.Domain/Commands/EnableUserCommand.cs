using Flunt.Notifications;
using Flunt.Validations;
using Leilao.Domain.Commands.Contracts;

namespace Leilao.Domain.Commands
{
    public class EnableUserCommand : Notifiable, ICommand
    {
        public EnableUserCommand() { }

        public EnableUserCommand(long id, string user)
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
                    .IsNotNullOrEmpty(User, "Usuário", "O usuário está vazio!")
            );
        }
    }
}
