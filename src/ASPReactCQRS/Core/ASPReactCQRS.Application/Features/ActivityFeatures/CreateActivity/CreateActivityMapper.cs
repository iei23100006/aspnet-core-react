using AutoMapper;
using ASPReactCQRS.Domain.Entities;

namespace ASPReactCQRS.Application.Features.ActivityFeatures.CreateActivity
{
    public sealed class CreateActivityMapper : Profile
    {
        public CreateActivityMapper() 
        {
            CreateMap<CreateActivityRequest, Activity>();
        }
    }
}
