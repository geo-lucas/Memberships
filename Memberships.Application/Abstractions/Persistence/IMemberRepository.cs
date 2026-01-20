using Memberships.Domain.Members;

namespace Memberships.Application.Abstractions.Persistence;

public interface IMemberRepository
{
    Task<Member?> GetByIdAsync(Guid id, CancellationToken ct);
    Task<Member?> GetByEmailAsync(string email, CancellationToken ct);
    Task AddAsync(Member member, CancellationToken ct);
}
