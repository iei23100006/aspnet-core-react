using MediatR;
using ASPReactCQRS.Application.Features.[FTName]Features.Get[FTName];

namespace ASPReactCQRS.Application.Features.[FTName]Features.Create[FTName]
{
    public sealed record Create[FTName]Request(string [FTName]Name, string CreatedById) : IRequest<Get[FTName]Response>;
}

public sealed record Create[FTName]Body
{
    public string [FTName]Name { get; set; } = default!;
}
