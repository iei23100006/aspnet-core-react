namespace ASPReactCQRS.Application.Features.UserFeatures.GetUser
{
    public sealed record GetUserResponse
    {
        public string Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string? Email { get; set; }
        public string? EmployeeId { get; set; }
        public string? Company { get; set; }
        public string? Department { get; set; }
        public string? Title { get; set; }
    }
}
