using Farmify_API_v2.src.Application.Common.Pagination;
using Farmify_API_v2.src.Application.Features.Users.DTOs;
using Farmify_API_v2.src.Application.Features.Users.Queries;
using Farmify_API_v2.src.Core.Interfaces.Repositories;
using MediatR;

namespace Farmify_API_v2.src.Application.Features.Users.Handlers
{
    public class GetUsersPagedHandler : IRequestHandler<GetUsersPagedQuery, PagedResult<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        public GetUsersPagedHandler(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<PagedResult<UserDto>> Handle(GetUsersPagedQuery request, CancellationToken ct)
        {
            var (users, total) = await _userRepository.GetPagedAsync(request.Page, request.PageSize, ct);
            var dto = users.Select(u =>
            new UserDto(u.ID, u.FirstName, u.LastName, u.Username, u.Email, u.Status)).ToList();

            return new PagedResult<UserDto>(
                dto,
                request.Page,
                request.PageSize,
                total);
        }
    }
}
