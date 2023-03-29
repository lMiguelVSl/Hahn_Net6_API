using AutoMapper;
using Hahn.DDD.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.DDD.Application.Features.Users.Queries.GetUserList
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<UserVm>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public GetUserListQueryHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<List<UserVm>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var userList = await _userRepository.GetAllAsync();
            return _mapper.Map<List<UserVm>>(userList);
        }
    }
}
