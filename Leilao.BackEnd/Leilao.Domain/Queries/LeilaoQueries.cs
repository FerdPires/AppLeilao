using System;
using System.Linq.Expressions;
using Leilao.Domain.Entities;

namespace Leilao.Domain.Queries
{
    public static class LeilaoQueries
    {
        public static Expression<Func<ItemLeilao, bool>> GetAllByUser(string user)
        {
            return x => x.User == user;
        }

        public static Expression<Func<ItemLeilao, bool>> GetById(long id, string user)
        {
            return x => x.User == user && x.Id == id;
        }
    }
}