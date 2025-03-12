namespace ASPReactCQRS.Domain.Entities
{
    public class Activity : Common.AuditableEntityBase
    {
        public string ActivityName { get; set; } = default!;
    }
}