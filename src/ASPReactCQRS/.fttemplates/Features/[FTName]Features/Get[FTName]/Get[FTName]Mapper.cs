using AutoMapper;
using ASPReactCQRS.Domain.Entities;

namespace ASPReactCQRS.Application.Features.[FTName]Features.Get[FTName]
{
    public sealed class Get[FTName]Mapper : Profile
    {
        public Get[FTName]Mapper()
        {
            CreateMap<Get[FTName]Request, [FTName]>();
            CreateMap<[FTName], Get[FTName]Response>()
                .ForMember(m => m.CreatedBy, m => m.MapFrom(u => u.CreatedBy != null ? u.CreatedBy.Name : null))
                .ForMember(m => m.UpdatedBy, m => m.MapFrom(u => u.UpdatedBy != null ? u.UpdatedBy.Name : null))
                .ForMember(m => m.DeletedBy, m => m.MapFrom(u => u.DeletedBy != null ? u.DeletedBy.Name : null));
        }
    }
}
