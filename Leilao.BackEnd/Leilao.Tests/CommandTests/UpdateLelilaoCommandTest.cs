using System;
using Leilao.Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Leilao.Tests.CommandTests
{
    [TestClass]
    public class UpdateLeilaoCommandTests
    {
        private readonly UpdateLeilaoCommand _invalidCommand = new UpdateLeilaoCommand(0, "", 0, false, DateTime.Now, DateTime.Now, "");
        private readonly UpdateLeilaoCommand _validCommand = new UpdateLeilaoCommand(1, "Leilão de livros usados", 20, true, new DateTime(2020, 10, 12, 12, 0, 0), new DateTime(2020, 10, 15, 12, 0, 0), "fernandapires01");

        public UpdateLeilaoCommandTests()
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
