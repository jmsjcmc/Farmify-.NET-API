using Farmify_API_v2.src.Application.Features.Users.DTOs;
using Farmify_API_v2.src.Application.Features.Users.Queries;
using Farmify_API_v2.src.Core.Interfaces.Repositories;
using MediatR;

namespace Farmify_API_v2.src.Application.Features.Users.Handlers
{
    public class GetUserByIDHandler : IRequestHandler<GetUserByIDQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIDHandler(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<UserDto> Handle(GetUserByIDQuery request, CancellationToken ct)
        {
            var user = await _userRepository.GetByIDAsync(request.ID, ct)
            ?? throw new Exception("User not found");

            return new UserDto(
                user.ID,
                user.FirstName,
                user.LastName,
                user.Username,
                user.Email,
                user.Status);
        }
    }
}
