using MediatR;


namespace ASPReactCQRS.Application.Features.[FTName]Features.Get[FTName]
{
    public sealed record Get[FTName]Request(long Id) : IRequest<Get[FTName]Response>;
}
