using System;
using Leilao.Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Leilao.Tests.CommandTests
{
    [TestClass]
    public class CreateLeilaoCommandTests
    {
        private readonly CreateLeilaoCommand _invalidCommand = new CreateLeilaoCommand("", 0, false, DateTime.Now, DateTime.Now, "", "");
        private readonly CreateLeilaoCommand _validCommand = new CreateLeilaoCommand("Leilão de uma tv", 20, false, new DateTime(2020, 10, 12, 12, 0, 0), new DateTime(2020, 10, 15, 12, 0, 0), "Fernanda", "fernandapires01");

        public CreateLeilaoCommandTests()
        {
            _invalidCommand.Validate();
            _validCommand.Validate();
        }

        [TestMethod]
        public void Dado_um_comando_invalido()
        {
            Assert.AreEqual(_invalidCommand.Valid, false);
        }

        [TestMethod]
        public void Dado_um_comando_valido()
        {
            Assert.AreEqual(_validCommand.Valid, true);
        }
    }
}
