using Hahn.DDD.Application.Features.Users.Commands.CreateUser;
using Hahn.DDD.Application.Features.Users.Commands.DeleteUser;
using Hahn.DDD.Application.Features.Users.Commands.UpdateUser;
using Hahn.DDD.Application.Features.Users.Queries.GetUserList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Hahn.DDD.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<UserVm>>> Get()
        {
            var query = new GetUserListQuery();
            var userList = await _mediator.Send(query);
            return userList;
        }

        [HttpPost(Name = "CreateUser")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> createUser([FromBody] CreateUserCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut(Name = "UpdateUser")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateUser([FromBody] UpdateUserCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete(Name = "DeleteUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var command = new DeleteUserCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

    }
}
