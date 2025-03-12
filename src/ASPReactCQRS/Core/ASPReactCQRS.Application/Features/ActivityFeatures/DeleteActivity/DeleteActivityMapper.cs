using AutoMapper;
using ASPReactCQRS.Domain.Entities;

namespace ASPReactCQRS.Application.Features.ActivityFeatures.DeleteActivity
{
    public sealed class DeleteActivityMapper : Profile
    {
        public DeleteActivityMapper() 
        {
            CreateMap<DeleteActivityRequest, Activity>();
        }
    }
}
