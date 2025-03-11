namespace ASPReactCQRS.Application.Features.[FTName]Features.Get[FTName]
{
    public sealed record Get[FTName]Response
    {
        public int Id { get; set; }
        public string [FTName]Name { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? DeletedBy { get; set; }
    }
}
