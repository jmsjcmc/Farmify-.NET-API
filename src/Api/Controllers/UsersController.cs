using Farmify_API_v2.src.Application.Features.Users.Commands;
using Farmify_API_v2.src.Application.Features.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Farmify_API_v2.src.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _mediator.Send(new GetAllUsersQuery()));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await _mediator.Send(new GetUserByIDQuery(id)));

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand request) => Ok(await _mediator.Send(request));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateUserCommand request)
        {
            if (id != request.ID) return BadRequest();
            await _mediator.Send(request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteUserCommand(id));
            return NoContent();
        }
    }
}
