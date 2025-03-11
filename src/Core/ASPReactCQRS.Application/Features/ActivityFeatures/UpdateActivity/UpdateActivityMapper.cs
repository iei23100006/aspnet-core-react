using AutoMapper;
using ASPReactCQRS.Domain.Entities;

namespace ASPReactCQRS.Application.Features.ActivityFeatures.UpdateActivity
{
    public sealed class UpdateActivityMapper : Profile
    {
        public UpdateActivityMapper() 
        {
            CreateMap<UpdateActivityBody, Activity>();
        }
    }
}
