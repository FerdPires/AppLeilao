using System;
using Leilao.Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Leilao.Tests.CommandTests
{
    [TestClass]
    public class DeleteLeilaoCommandTests
    {
        private readonly DeleteLeilaoCommand _invalidCommand = new DeleteLeilaoCommand(0, "");
        private readonly DeleteLeilaoCommand _validCommand = new DeleteLeilaoCommand(1, "fernandapires01");

        public DeleteLeilaoCommandTests()
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