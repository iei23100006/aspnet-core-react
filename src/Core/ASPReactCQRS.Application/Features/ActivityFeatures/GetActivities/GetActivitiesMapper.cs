using ASPReactCQRS.Domain.Entities;
using AutoMapper;

namespace ASPReactCQRS.Application.Features.ActivityFeatures.GetActivities
{
    public sealed class GetActivitiesMapper : Profile
    {
        public GetActivitiesMapper()
        {
            AllowNullCollections = true;
            CreateMap<GetActivitiesRequest, Activity>();
            CreateMap<IEnumerable<Activity>, GetActivitiesResponse>()
                .ForMember(m => m.Activities, m => m.MapFrom(l => l));
        }
    }
    
}
