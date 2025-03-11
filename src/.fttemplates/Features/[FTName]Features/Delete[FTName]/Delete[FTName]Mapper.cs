using AutoMapper;
using ASPReactCQRS.Domain.Entities;

namespace ASPReactCQRS.Application.Features.[FTName]Features.Delete[FTName]
{
    public sealed class Delete[FTName]Mapper : Profile
    {
        public Delete[FTName]Mapper() 
        {
            CreateMap<Delete[FTName]Request, [FTName]>();
        }
    }
}
