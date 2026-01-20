namespace Memberships.Domain.Common;

public abstract class AuditableEntity : Entity, ISoftDeletable
{
    public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; protected set; }

    public bool IsDeleted { get; protected set; }
    public DateTime? DeletedAt { get; protected set; }

    public void Touch()
        => UpdatedAt = DateTime.UtcNow;

    public void SoftDelete()
    {
        IsDeleted = true;
        DeletedAt = DateTime.UtcNow;
    }
}
