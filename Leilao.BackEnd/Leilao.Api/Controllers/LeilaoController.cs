using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Leilao.Domain.Commands;
using Leilao.Domain.Entities;
using Leilao.Domain.Repositories;
using Leilao.Domain.Handlers;
using System;

namespace Leilao.Api.Controllers
{
    [ApiController]
    [Route("v1/leiloes")]
    [Authorize]
    public class LeilaoController : ControllerBase
    {
        [Route("all")]
        [HttpGet]
        public IEnumerable<ItemLeilao> GetAll(
            [FromServices] ILeilaoRepository repository
        )
        {
            return repository.GetAll();
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<ItemLeilao> GetAllByUser(
            [FromServices] ILeilaoRepository repository
        )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return repository.GetAllByUser(user);
        }

        [Route("")]
        [HttpPost]
        public GenericCommandResult Create(
            [FromBody] CreateLeilaoCommand command,
            [FromServices] LeilaoHandler handler
        )
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        public GenericCommandResult Update(
           [FromBody] UpdateLeilaoCommand command,
           [FromServices] LeilaoHandler handler
        )
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("{id}")]
        [HttpDelete]
        public GenericCommandResult Delete(
            long id,
           [FromServices] LeilaoHandler handler
        )
        {
            var command = new DeleteLeilaoCommand();

            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            command.Id = id;
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("{id}")]
        [HttpGet]
        public ItemLeilao GetById(
            long id,
            [FromServices] ILeilaoRepository repository
        )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return repository.GetById(id, user);
        }
    }
}