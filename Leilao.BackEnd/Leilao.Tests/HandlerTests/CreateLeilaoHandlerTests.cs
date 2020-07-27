using System;
using Leilao.Domain.Commands;
using Leilao.Domain.Handlers;
using Leilao.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Leilao.Tests.HandlerTests
{
    [TestClass]
    public class CreateLeilaoHandlerTests
    {
        private readonly CreateLeilaoCommand _invalidCommand = new CreateLeilaoCommand("", 0, false, DateTime.Now, DateTime.Now, "", "");
        private readonly CreateLeilaoCommand _validCommand = new CreateLeilaoCommand("Leilão de uma tv", 20, false, new DateTime(2020, 10, 12, 12, 0, 0), new DateTime(2020, 10, 15, 12, 0, 0), "Fernanda", "fernandapires01");
        private readonly LeilaoHandler _handler = new LeilaoHandler(new FakeLeilaoRepository());
        private GenericCommandResult _result = new GenericCommandResult();

        public CreateLeilaoHandlerTests()
        {

        }

        [TestMethod]
        public void Dado_um_comando_invalido_deve_interromper_a_execucao()
        {
            _result = (GenericCommandResult)_handler.Handle(_invalidCommand);
            Assert.AreEqual(_result.Success, false);
        }

        [TestMethod]
        public void Dado_um_comando_valido_deve_criar_o_leilao()
        {
            _result = (GenericCommandResult)_handler.Handle(_validCommand);
            Assert.AreEqual(_result.Success, true);
        }
    }
}
