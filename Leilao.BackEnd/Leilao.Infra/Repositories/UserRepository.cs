using Leilao.Domain.Entities;
using Leilao.Domain.Queries;
using Leilao.Domain.Repositories;
using Leilao.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Leilao.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public UserAccount GetUser(string user)
        {
            return _context.Users.FirstOrDefault(x => x.User == user);
        }

        public void Create(UserAccount user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(UserAccount user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<UserAccount> GetAllUsers()
        {
            return _context.Users.AsNoTracking().OrderBy(x => x.Id);
        }
    }
}
