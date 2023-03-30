using AutoMapper;
using Hahn.DDD.Application.Contracts.Persistence;
using Hahn.DDD.Application.Exceptions;
using Hahn.DDD.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Hahn.DDD.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteUserCommandHandler> _logger;

        public DeleteUserCommandHandler(IUserRepository userRepository, IMapper mapper, ILogger<DeleteUserCommandHandler> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var getUser = await _userRepository.GetByIdAsync(request.Id);
            if (getUser == null)
            {
                _logger.LogError($"User with id: {request.Id} was not found");
                throw new NotFoundException(nameof(User), request.Id);
            }

            await _userRepository.DeleteAsync(getUser);
            _logger.LogInformation($"User with id: {request.Id} was Deleted successfully");

            return Unit.Value;
        }
    }
}
