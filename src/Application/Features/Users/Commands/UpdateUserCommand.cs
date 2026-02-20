using MediatR;

namespace Farmify_API_v2.src.Application.Features.Users.Commands
{
    public record UpdateUserCommand(
        int ID,
        string FirstName,
        string LastName,
        string Username,
        string Email) : IRequest;
}
