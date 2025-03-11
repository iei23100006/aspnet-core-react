using AutoMapper;
using ASPReactCQRS.Domain.Entities;

namespace ASPReactCQRS.Application.Features.[FTName]Features.Update[FTName]
{
    public sealed class Update[FTName]Mapper : Profile
    {
        public Update[FTName]Mapper() 
        {
            CreateMap<Update[FTName]Body, [FTName]>();
        }
    }
}
