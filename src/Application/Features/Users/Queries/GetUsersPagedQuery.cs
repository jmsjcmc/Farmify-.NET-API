using Farmify_API_v2.src.Application.Common.Pagination;
using Farmify_API_v2.src.Application.Features.Users.DTOs;
using MediatR;

namespace Farmify_API_v2.src.Application.Features.Users.Queries
{
    public record GetUsersPagedQuery(int Page = 1, int PageSize = 10) : IRequest<PagedResult<UserDto>>;
}
