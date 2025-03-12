using AutoMapper;
using ASPReactCQRS.Domain.Entities;

namespace ASPReactCQRS.Application.Features.ActivityFeatures.GetActivity
{
    public sealed class GetActivityMapper : Profile
    {
        public GetActivityMapper()
        {
            CreateMap<GetActivityRequest, Activity>();
            CreateMap<Activity, GetActivityResponse>()
                .ForMember(m => m.CreatedBy, m => m.MapFrom(u => u.CreatedBy != null ? u.CreatedBy.Name : null))
                .ForMember(m => m.UpdatedBy, m => m.MapFrom(u => u.UpdatedBy != null ? u.UpdatedBy.Name : null))
                .ForMember(m => m.DeletedBy, m => m.MapFrom(u => u.DeletedBy != null ? u.DeletedBy.Name : null));
        }
    }
}
