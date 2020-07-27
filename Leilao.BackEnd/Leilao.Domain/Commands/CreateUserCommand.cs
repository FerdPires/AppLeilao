using Flunt.Notifications;
using Flunt.Validations;
using Leilao.Domain.Commands.Contracts;

namespace Leilao.Domain.Commands
{
    public class CreateUserCommand : Notifiable, ICommand
    {
        public CreateUserCommand() { }

        public CreateUserCommand(string user)
        {
            usuario_ativo = true;
            User = user;
        }

        public bool usuario_ativo { get; set; }
        public string User { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(User, "Usuário", "O user não pode ser nulo!")
             );
        }
    }
}
