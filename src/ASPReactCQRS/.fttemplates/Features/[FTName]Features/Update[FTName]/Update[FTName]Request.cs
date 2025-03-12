using MediatR;
using ASPReactCQRS.Application.Features.[FTName]Features.Get[FTName];

namespace ASPReactCQRS.Application.Features.[FTName]Features.Update[FTName]
{
    public sealed record Update[FTName]Request(Update[FTName]Body [FTName]Body, string UpdatedById) : IRequest<Get[FTName]Response>;
}

public sealed record Update[FTName]Body 
{
    public long Id { get; set; }
    public string [FTName]Name { get; set; } = default!;
}
