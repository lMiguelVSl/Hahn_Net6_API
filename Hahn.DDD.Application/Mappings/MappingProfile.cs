using AutoMapper;
using Hahn.DDD.Application.Features.Users.Commands.CreateUser;
using Hahn.DDD.Application.Features.Users.Queries.GetUserList;
using Hahn.DDD.Domain;

namespace Hahn.DDD.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserVm>();
            CreateMap<CreateUserCommand,User>();
        }
    }
}
