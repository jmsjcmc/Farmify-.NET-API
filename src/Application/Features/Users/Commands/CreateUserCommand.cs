using Farmify_API_v2.src.Application.Features.Users.DTOs;
using MediatR;

namespace Farmify_API_v2.src.Application.Features.Users.Commands
{
    public record CreateUserCommand(
        string FirstName,
        string LastName,
        string Username,
        string Email,
        string Password) : IRequest<UserDto>;
}
