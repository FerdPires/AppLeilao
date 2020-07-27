using Leilao.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace Leilao.Domain.Queries
{
    public static class UserQueries
    {
        public static Expression<Func<UserAccount, bool>> GetUser(string user)
        {
            return x => x.User == user;
        }
    }
}
