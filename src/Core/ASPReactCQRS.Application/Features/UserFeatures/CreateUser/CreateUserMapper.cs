using AutoMapper;
using ASPReactCQRS.Domain.Entities;

namespace ASPReactCQRS.Application.Features.UserFeatures.CreateUser
{
    public sealed class CreateUserMapper : Profile
    {
        public CreateUserMapper() 
        {
            CreateMap<CreateUserRequest, User>()
                .ForMember(m => m.CreatedAt, m => m.MapFrom(_ => DateTime.UtcNow));
            CreateMap<User, CreateUserResponse>();
        }
    }
}
