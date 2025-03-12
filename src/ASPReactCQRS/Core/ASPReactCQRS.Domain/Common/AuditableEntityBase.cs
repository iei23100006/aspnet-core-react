namespace ASPReactCQRS.Domain.Common
{
    public abstract class AuditableEntityBase
    {
        public long Id { get; set; }
        private DateTime _createdAt;
        public DateTime CreatedAt
        {
            get => _createdAt.Kind == DateTimeKind.Unspecified ? DateTime.SpecifyKind(_createdAt, DateTimeKind.Utc) : _createdAt;
            set => _createdAt = value;
        }
        public string? CreatedById { get; set; }
        public Entities.User? CreatedBy { get; set; }
        private DateTime? _updatedAt;
        public DateTime? UpdatedAt
        {
            get => _updatedAt.HasValue && _updatedAt?.Kind == DateTimeKind.Unspecified ? DateTime.SpecifyKind(_updatedAt.Value, DateTimeKind.Utc) : _updatedAt;
            set => _updatedAt = value;
        }
        public string? UpdatedById { get; set; }
        public Entities.User? UpdatedBy { get; set; }
        private DateTime? _deletedAt;
        public DateTime? DeletedAt
        {
            get => _deletedAt.HasValue && _deletedAt?.Kind == DateTimeKind.Unspecified ? DateTime.SpecifyKind(_deletedAt.Value, DateTimeKind.Utc) : _deletedAt;
            set => _deletedAt = value;
        }
        public string? DeletedById { get; set; }
        public Entities.User? DeletedBy { get; set; }

    }
}