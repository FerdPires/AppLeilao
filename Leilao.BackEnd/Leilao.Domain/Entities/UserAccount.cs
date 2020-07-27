namespace Leilao.Domain.Entities
{
    public class UserAccount : Entity
    {
        public UserAccount()
        {

        }

        public UserAccount(string user)
        {
            usuario_ativo = true;
            User = user;
        }

        public bool usuario_ativo { get; set; }
        public string User { get; private set; }

        public void EnableUser(string user)
        {
            usuario_ativo = true;
            User = user;
        }

        public void DisableUser(string user)
        {
            usuario_ativo = false;
            User = user;
        }
    }
}
