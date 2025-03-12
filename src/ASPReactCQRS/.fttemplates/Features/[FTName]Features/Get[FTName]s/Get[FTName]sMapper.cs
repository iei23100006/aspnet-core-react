using ASPReactCQRS.Domain.Entities;
using AutoMapper;

namespace ASPReactCQRS.Application.Features.[FTName]Features.Get[FTName]s
{
    public sealed class Get[FTName]sMapper : Profile
    {
        public Get[FTName]sMapper()
        {
            AllowNullCollections = true;
            CreateMap<Get[FTName]sRequest, [FTName]>();
            CreateMap<IEnumerable<[FTName]>, Get[FTName]sResponse>()
                .ForMember(m => m.[FTName]s, m => m.MapFrom(l => l));
        }
    }
    
}
