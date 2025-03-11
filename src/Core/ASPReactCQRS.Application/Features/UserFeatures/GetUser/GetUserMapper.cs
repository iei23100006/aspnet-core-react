using AutoMapper;
using ASPReactCQRS.Domain.Entities;

namespace ASPReactCQRS.Application.Features.UserFeatures.GetUser
{
    public sealed class GetUserMapper : Profile
    {
        public GetUserMapper()
        {
            CreateMap<GetUserRequest, User>();
            CreateMap<User, GetUserResponse>();
        }
    }
}
