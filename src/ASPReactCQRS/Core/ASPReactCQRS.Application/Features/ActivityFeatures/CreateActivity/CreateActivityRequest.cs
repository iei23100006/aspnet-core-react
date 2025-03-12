using MediatR;
using ASPReactCQRS.Application.Features.ActivityFeatures.GetActivity;

namespace ASPReactCQRS.Application.Features.ActivityFeatures.CreateActivity
{
    public sealed record CreateActivityRequest(string ActivityName, string CreatedById) : IRequest<GetActivityResponse>;
}

public sealed record CreateActivityBody
{
    public string ActivityName { get; set; } = default!;
}
