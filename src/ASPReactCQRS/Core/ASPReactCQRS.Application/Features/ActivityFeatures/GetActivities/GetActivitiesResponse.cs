namespace ASPReactCQRS.Application.Features.ActivityFeatures.GetActivities
{
    public sealed record GetActivitiesResponse
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public long TotalRows { get; set; }
        public IEnumerable<ActivityFeatures.GetActivity.GetActivityResponse> Activities { get; set; } = Enumerable.Empty<GetActivity.GetActivityResponse>();
    }
}
