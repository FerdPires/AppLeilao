using System.Collections.Generic;
using System.Linq;
using Leilao.Domain.Entities;
using Leilao.Infra.Contexts;
using Leilao.Domain.Queries;
using Leilao.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Leilao.Infra.Repositories
{
    public class LeilaoRepository : ILeilaoRepository
    {
        private readonly DataContext _context;

        public LeilaoRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(ItemLeilao leilao)
        {
            _context.Leiloes.Add(leilao);
            _context.SaveChanges();
        }

        public void Delete(ItemLeilao leilao)
        {
            _context.Leiloes.Remove(leilao);
            _context.SaveChanges();
        }

        public IEnumerable<ItemLeilao> GetAll()
        {
            return _context.Leiloes.AsNoTracking().OrderBy(x => x.nome_leilao);
        }

        public IEnumerable<ItemLeilao> GetAllByUser(string user)
        {
            return _context.Leiloes.AsNoTracking().Where(LeilaoQueries.GetAllByUser(user)).OrderBy(x => x.nome_leilao);
        }

        public ItemLeilao GetById(long id, string user)
        {
            return _context.Leiloes.FirstOrDefault(x => x.Id == id && x.User == user);
        }

        public void Update(ItemLeilao leilao)
        {
            _context.Entry(leilao).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}