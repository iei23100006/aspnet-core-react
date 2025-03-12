using MediatR;
using ASPReactCQRS.Application.Features.ActivityFeatures.GetActivity;

namespace ASPReactCQRS.Application.Features.ActivityFeatures.UndeleteActivity
{
    public sealed record UndeleteActivityRequest(long Id, string UpdatedById) : IRequest<GetActivityResponse>;
}
