using System.Collections.Generic;
using Leilao.Domain.Entities;

namespace Leilao.Domain.Repositories
{
    public interface ILeilaoRepository
    {
        void Create(ItemLeilao leilao);
        void Update(ItemLeilao leilao);
        void Delete(ItemLeilao leilao);
        ItemLeilao GetById(long id, string user);
        IEnumerable<ItemLeilao> GetAllByUser(string user);
        IEnumerable<ItemLeilao> GetAll();
    }
}