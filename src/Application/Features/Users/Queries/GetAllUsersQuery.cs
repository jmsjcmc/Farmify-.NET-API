using Farmify_API_v2.src.Application.Features.Users.DTOs;
using MediatR;

namespace Farmify_API_v2.src.Application.Features.Users.Queries
{
    public record GetAllUsersQuery() : IRequest<List<UserDto>>;
}
