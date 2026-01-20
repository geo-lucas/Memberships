namespace Memberships.Application.Members.Queries.GetMemberById;

public sealed class MemberDto
{
    public Guid Id { get; init; }
    public string Email { get; init; } = default!;
    public string FullName { get; init; } = default!;
    public bool IsActive { get; init; }
}
