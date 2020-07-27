using System;
using System.Collections.Generic;
using Leilao.Domain.Entities;
using Leilao.Domain.Repositories;

namespace Leilao.Tests.Repositories
{
    public class FakeLeilaoRepository : ILeilaoRepository
    {
        public void Create(ItemLeilao leilao)
        {

        }

        public void Delete(ItemLeilao leilao)
        {

        }

        public ItemLeilao GetById(long id, string user)
        {
            return new ItemLeilao("Título Leilão", 150, false, new DateTime(2020, 10, 12, 12, 0, 0), new DateTime(2020, 10, 15, 12, 0, 0), "Fernanda", "fernandapires01");
        }

        public IEnumerable<ItemLeilao> GetAllByUser(string user)
        {
            throw new NotImplementedException();
        }

        public void Update(ItemLeilao leilao)
        {

        }

        public IEnumerable<ItemLeilao> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}