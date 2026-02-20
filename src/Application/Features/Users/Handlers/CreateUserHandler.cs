using Farmify_API_v2.src.Application.Features.Interfaces.UnitOfWork;
using Farmify_API_v2.src.Application.Features.Users.Commands;
using Farmify_API_v2.src.Application.Features.Users.DTOs;
using Farmify_API_v2.src.Core.Entities;
using Farmify_API_v2.src.Core.Interfaces.Repositories;
using MediatR;

namespace Farmify_API_v2.src.Application.Features.Users.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDto> Handle (CreateUserCommand request, CancellationToken ct)
        {
            var exist = await _userRepository.GetByUsernameAsync(request.Username, ct);
            if (exist != null)
                throw new Exception("User already exists");

            var user = new User(request.FirstName, request.LastName, request.Username, request.Email);

            await _userRepository.AddAsync(user, ct);
            await _unitOfWork.SaveChangesAsync(ct);

            return new UserDto(
                user.ID,
                user.FirstName,
                user.LastName,
                user.Username,
                user.Email,
                user.IsActive);
        }
    }
}
