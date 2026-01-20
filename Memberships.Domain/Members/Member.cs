using Memberships.Domain.Common;

namespace Memberships.Domain.Members;

public class Member : AuditableEntity
{
    public string Email { get; private set; } = default!;
    public string FullName { get; private set; } = default!;
    public bool IsActive { get; private set; }

    private Member() { }

    public Member(string email, string fullName)
    {
        Email = email.ToLowerInvariant();
        FullName = fullName;
        IsActive = true;
    }

    public void Deactivate()
    {
        IsActive = false;
        Touch();
    }
}
