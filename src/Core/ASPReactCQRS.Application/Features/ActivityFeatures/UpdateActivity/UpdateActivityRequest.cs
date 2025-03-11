using MediatR;
using ASPReactCQRS.Application.Features.ActivityFeatures.GetActivity;

namespace ASPReactCQRS.Application.Features.ActivityFeatures.UpdateActivity
{
    public sealed record UpdateActivityRequest(UpdateActivityBody ActivityBody, string UpdatedById) : IRequest<GetActivityResponse>;
}

public sealed record UpdateActivityBody 
{
    public long Id { get; set; }
    public string ActivityName { get; set; } = default!;
}
