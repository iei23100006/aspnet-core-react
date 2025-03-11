namespace ASPReactCQRS.Application.Features.UserFeatures.CreateUser
{
    public sealed record CreateUserResponse
    {
        public string Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string? Email { get; set; }
        public string? VendorCode { get; set; }
        public string? Company { get; set; }
        }
}
