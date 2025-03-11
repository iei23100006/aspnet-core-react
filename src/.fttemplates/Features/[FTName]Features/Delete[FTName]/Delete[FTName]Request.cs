using MediatR;
using ASPReactCQRS.Application.Features.[FTName]Features.Get[FTName];

namespace ASPReactCQRS.Application.Features.[FTName]Features.Delete[FTName]
{
    public sealed record Delete[FTName]Request(long Id, string DeletedById) : IRequest<Get[FTName]Response>;
}
