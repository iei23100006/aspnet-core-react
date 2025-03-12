using AutoMapper;
using ASPReactCQRS.Domain.Entities;

namespace ASPReactCQRS.Application.Features.[FTName]Features.Undelete[FTName]
{
    public sealed class Undelete[FTName]Mapper : Profile
    {
        public Undelete[FTName]Mapper() 
        {
            CreateMap<Undelete[FTName]Request, [FTName]>();
        }
    }
}
