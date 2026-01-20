using Memberships.Domain.Subscriptions;

namespace Memberships.Application.Abstractions.Persistence;

public interface ISubscriptionRepository
{
    Task<Subscription?> GetByIdAsync(Guid id, CancellationToken ct);
    Task AddAsync(Subscription subscription, CancellationToken ct);
    Task SaveChangesAsync(CancellationToken ct);
}
