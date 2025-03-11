using AutoMapper;
using ASPReactCQRS.Domain.Entities;

namespace ASPReactCQRS.Application.Features.[FTName]Features.Create[FTName]
{
    public sealed class Create[FTName]Mapper : Profile
    {
        public Create[FTName]Mapper() 
        {
            CreateMap<Create[FTName]Request, [FTName]>();
        }
    }
}
