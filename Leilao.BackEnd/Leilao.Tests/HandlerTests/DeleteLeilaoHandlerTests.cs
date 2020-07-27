using System;
using Leilao.Domain.Commands;
using Leilao.Domain.Handlers;
using Leilao.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Leilao.Tests.HandlerTests
{
    [TestClass]
    public class DeleteLeilaoHandlerTests
    {
        private readonly DeleteLeilaoCommand _invalidCommand = new DeleteLeilaoCommand(0, "");
        private readonly DeleteLeilaoCommand _validCommand = new DeleteLeilaoCommand(1, "fernandapires01");
        private readonly LeilaoHandler _handler = new LeilaoHandler(new FakeLeilaoRepository());
        private GenericCommandResult _result = new GenericCommandResult();

        public DeleteLeilaoHandlerTests()
        {

        }

        [TestMethod]
        public void Dado_um_comando_invalido_deve_interromper_a_execucao()
        {
            _result = (GenericCommandResult)_handler.Handle(_invalidCommand);
            Assert.AreEqual(_result.Success, false);
        }

        [TestMethod]
        public void Dado_um_comando_valido_deve_excluir_o_leilao()
        {
            _result = (GenericCommandResult)_handler.Handle(_validCommand);
            Assert.AreEqual(_result.Success, true);
        }
    }
}
