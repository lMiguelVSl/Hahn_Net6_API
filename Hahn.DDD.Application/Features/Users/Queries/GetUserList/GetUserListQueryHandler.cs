using AutoMapper;
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
        //constructor and injecton of userrepository and d

        public GetUserListQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public Task<List<UserVm>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
