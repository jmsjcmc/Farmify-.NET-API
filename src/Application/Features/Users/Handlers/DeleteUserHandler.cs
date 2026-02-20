using Farmify_API_v2.src.Application.Features.Interfaces.UnitOfWork;
using Farmify_API_v2.src.Application.Features.Users.Commands;
using Farmify_API_v2.src.Core.Interfaces.Repositories;
using MediatR;

namespace Farmify_API_v2.src.Application.Features.Users.Handlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteUserCommand request, CancellationToken ct)
        {
            var user = await _userRepository.GetByIDAsync(request.ID, ct)
                ?? throw new Exception("User not found");

            _userRepository.Remove(user);
            await _unitOfWork.SaveChangesAsync(ct);
        }
    }
}
