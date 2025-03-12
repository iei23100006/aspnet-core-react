using AutoMapper;
using ASPReactCQRS.Domain.Entities;

namespace ASPReactCQRS.Application.Features.ActivityFeatures.UndeleteActivity
{
    public sealed class UndeleteActivityMapper : Profile
    {
        public UndeleteActivityMapper() 
        {
            CreateMap<UndeleteActivityRequest, Activity>();
        }
    }
}
