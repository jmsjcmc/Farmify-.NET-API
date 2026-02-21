using Farmify_API_v2.src.Application.Features.Interfaces.UnitOfWork;
using Farmify_API_v2.src.Application.Features.Users.Commands;
using Farmify_API_v2.src.Application.Interfaces;
using Farmify_API_v2.src.Core.Interfaces.Repositories;
using MediatR;

namespace Farmify_API_v2.src.Application.Features.Users.Handlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider;
        public UpdateUserHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IDateTimeProvider dateTimeProvider)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task Handle(UpdateUserCommand request, CancellationToken ct)
        {
            var user = await _userRepository.GetByIDAsync(request.ID, ct)
                ?? throw new Exception("User not found");

            user.Update(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Username,
                _dateTimeProvider.Now
            );

            await _unitOfWork.SaveChangesAsync(ct);
        }
    }
}
