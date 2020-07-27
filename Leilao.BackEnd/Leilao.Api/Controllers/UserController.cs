using System.Collections.Generic;
using System.Linq;
using Leilao.Domain.Commands;
using Leilao.Domain.Entities;
using Leilao.Domain.Handlers;
using Leilao.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Leilao.Api.Controllers
{
    [ApiController]
    [Route("v1/leiloes/user")]
    public class UserController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        [Authorize]
        public UserAccount GetUser(
            [FromServices] IUserRepository repository,
            [FromServices] UserHandler handler
        )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            var userAccount = repository.GetUser(user);

            if (userAccount == null)
            {
                var command = new CreateUserCommand(user);
                command.User = user;
                var result = (GenericCommandResult)handler.Handle(command);
            }
            return repository.GetUser(user);
        }

        [Route("all")]
        [HttpGet]
        public IEnumerable<UserAccount> GetAll(
           [FromServices] IUserRepository repository
        )
        {
            return repository.GetAllUsers();
        }

        [Route("enable")]
        [HttpPut]
        public GenericCommandResult EnableUser(
            [FromBody] EnableUserCommand command,
            [FromServices] UserHandler handler,
            [FromServices] IUserRepository repository
        )
        {
            var userAccout = new UserAccount();
            userAccout = repository.GetUser(command.User);
            command.Id = userAccout.Id;

            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("disable")]
        [HttpPut]
        public GenericCommandResult DisableUser(
            [FromBody] DisableUserCommand command,
            [FromServices] UserHandler handler,
            [FromServices] IUserRepository repository
        )
        {
            var userAccout = new UserAccount();
            userAccout = repository.GetUser(command.User);
            command.Id = userAccout.Id;

            return (GenericCommandResult)handler.Handle(command);
        }
    }
}
