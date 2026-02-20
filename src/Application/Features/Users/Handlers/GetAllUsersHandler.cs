using Farmify_API_v2.src.Application.Features.Users.DTOs;
using Farmify_API_v2.src.Application.Features.Users.Queries;
using Farmify_API_v2.src.Core.Interfaces.Repositories;
using MediatR;

namespace Farmify_API_v2.src.Application.Features.Users.Handlers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<UserDto>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersHandler(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<List<UserDto>> Handle(GetAllUsersQuery request, CancellationToken ct)
        {
            var users = await _userRepository.GetAllAsync(ct);

            return users.Select(u => new UserDto(
                u.ID,
                u.FirstName,
                u.LastName,
                u.Username,
                u.Email,
                u.IsActive)).ToList();
        }

    }
}
