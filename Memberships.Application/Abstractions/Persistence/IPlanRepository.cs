using Memberships.Domain.Plans;

namespace Memberships.Application.Abstractions.Persistence;

public interface IPlanRepository
{
    Task<MembershipPlan?> GetByIdAsync(Guid id, CancellationToken ct);
    Task AddAsync(MembershipPlan plan, CancellationToken ct);
}
