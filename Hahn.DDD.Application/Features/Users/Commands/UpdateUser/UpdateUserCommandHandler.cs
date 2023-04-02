using AutoMapper;
using Hahn.DDD.Application.Contracts.Persistence;
using Hahn.DDD.Application.Exceptions;
using Hahn.DDD.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Hahn.DDD.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateUserCommandHandler> _logger;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper, ILogger<UpdateUserCommandHandler> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var getUser = await _userRepository.GetByIdAsync(request.Id);
            if (getUser == null)
            {
                _logger.LogError($"User with id: {request.Id} was not found");
                throw new NotFoundException(nameof(User), request.Id);
            }

            _mapper.Map(request, getUser, typeof(UpdateUserCommand), typeof(User));
            await _userRepository.UpdateAsync(getUser);

            _logger.LogInformation($"User with id: {request.Id} was updated");

            return getUser.Id;
        }
    }
}
