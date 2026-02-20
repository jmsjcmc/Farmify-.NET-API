using MediatR;

namespace Farmify_API_v2.src.Application.Features.Users.Commands
{
    public record DeleteUserCommand(int ID) : IRequest;

}
