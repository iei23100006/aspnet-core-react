using MediatR;
using ASPReactCQRS.Application.Features.ActivityFeatures.GetActivity;

namespace ASPReactCQRS.Application.Features.ActivityFeatures.DeleteActivity
{
    public sealed record DeleteActivityRequest(long Id, string DeletedById) : IRequest<GetActivityResponse>;
}
