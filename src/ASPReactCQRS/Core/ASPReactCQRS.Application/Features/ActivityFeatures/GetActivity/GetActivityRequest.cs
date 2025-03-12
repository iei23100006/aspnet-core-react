using MediatR;


namespace ASPReactCQRS.Application.Features.ActivityFeatures.GetActivity
{
    public sealed record GetActivityRequest(long Id) : IRequest<GetActivityResponse>;
}
