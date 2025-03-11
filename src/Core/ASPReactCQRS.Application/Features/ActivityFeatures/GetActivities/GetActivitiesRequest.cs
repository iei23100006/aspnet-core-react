using MediatR;

namespace ASPReactCQRS.Application.Features.ActivityFeatures.GetActivities
{
    public sealed record GetActivitiesRequest(int PageIndex, int PageSize, bool IsActive) : IRequest<GetActivitiesResponse>;
}


