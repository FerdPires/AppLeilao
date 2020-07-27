using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leilao.Domain.Entities;
using Leilao.Domain.Queries;

namespace Leilao.Tests.QueriesTests
{
    [TestClass]
    public class QueriesTests
    {
        private List<ItemLeilao> _items;

        public QueriesTests()
        {
            _items = new List<ItemLeilao>();
            _items.Add(new ItemLeilao("Leilão 1", 120, false, new DateTime(2020, 10, 12, 12, 0, 0), new DateTime(2020, 10, 12, 12, 0, 0), "Fernanda", "fernandapires01"));
            _items.Add(new ItemLeilao("Leilão 2", 120, true, new DateTime(2020, 9, 13, 22, 0, 0), new DateTime(2020, 9, 20, 22, 0, 0), "João", "usuario1"));
            _items.Add(new ItemLeilao("Leilão 3", 120, true, new DateTime(2020, 10, 1, 11, 0, 0), new DateTime(2020, 10, 10, 11, 0, 0), "Maria", "usuario2"));
            _items.Add(new ItemLeilao("Leilão 4", 120, false, new DateTime(2020, 11, 5, 12, 0, 0), new DateTime(2020, 11, 30, 12, 0, 0), "Fernanda", "fernandapires01"));
            _items.Add(new ItemLeilao("Leilão 5", 120, true, new DateTime(2020, 7, 28, 19, 0, 0), new DateTime(2020, 7, 28, 22, 0, 0), "Fernanda", "fernandapires01"));
        }

        [TestMethod]
        public void Dada_a_consulta_deve_retornar_leiloes_apenas_do_usuario_fernandapires01()
        {
            var result = _items.AsQueryable().Where(LeilaoQueries.GetAllByUser("fernandapires01"));
            Assert.AreEqual(3, result.Count());
        }
    }
}