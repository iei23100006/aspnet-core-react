namespace ASPReactCQRS.Application.Features.ActivityFeatures.GetActivity
{
    public sealed record GetActivityResponse
    {
        public int Id { get; set; }
        public string ActivityName { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? DeletedBy { get; set; }
    }
}
