using MediatR;

namespace ASPReactCQRS.Application.Features.[FTName]Features.Get[FTName]s
{
    public sealed record Get[FTName]sRequest(int PageIndex, int PageSize, bool IsActive) : IRequest<Get[FTName]sResponse>;
}


