using BlackBox.Api.Results;
using BlackBox.Core.Features.Users.Commands.Create;
using BlackBox.Core.Features.Users.Commands.Delete;
using BlackBox.Core.Features.Users.Commands.Update;
using BlackBox.Core.Features.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Emit;

namespace BlackBox.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getUserList")]
        public async Task<IActionResult> GetUserList([FromRoute] GetUserList.Query query)
            => await ApiResult.ResponseAsync(async () => await _mediator.Send(query));

        [HttpPost("insertUser")]
        public async Task<IActionResult> InsertUser([FromBody] InsertUser.InsertUserCommand command)
            => await ApiResult.ResponseAsync(async () => await _mediator.Send(command));

        [HttpPut("updateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUser.UpdateUserCommand command)
            => await ApiResult.ResponseAsync(async () => await _mediator.Send(command));

        [HttpDelete("deleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(DeleteUser.DeleteUserCommand command)
            => await ApiResult.ResponseAsync(async () => await _mediator.Send(command));

        
    }
}
