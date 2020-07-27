using Leilao.Domain.Entities;
using System.Collections.Generic;

namespace Leilao.Domain.Repositories
{
    public interface IUserRepository
    {
        void Create(UserAccount user);
        void Update(UserAccount user);
        UserAccount GetUser(string user);
        IEnumerable<UserAccount> GetAllUsers();
    }
}
