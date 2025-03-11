using MediatR;
using ASPReactCQRS.Application.Features.[FTName]Features.Get[FTName];

namespace ASPReactCQRS.Application.Features.[FTName]Features.Undelete[FTName]
{
    public sealed record Undelete[FTName]Request(long Id, string UpdatedById) : IRequest<Get[FTName]Response>;
}
