using Memberships.Domain.Common;
using Memberships.Domain.Members;
using Memberships.Domain.Plans;

namespace Memberships.Domain.Subscriptions;

public class Subscription : AuditableEntity
{
    public Guid MemberId { get; private set; }
    public Guid PlanId { get; private set; }

    public SubscriptionStatus Status { get; private set; }

    public DateTime StartedAt { get; private set; }
    public DateTime? CanceledAt { get; private set; }

    private readonly List<SubscriptionPeriod> _periods = new();
    public IReadOnlyCollection<SubscriptionPeriod> Periods => _periods.AsReadOnly();

    private Subscription() { }

    public Subscription(Guid memberId, Guid planId)
    {
        MemberId = memberId;
        PlanId = planId;
        Status = SubscriptionStatus.Pending;
        StartedAt = DateTime.UtcNow;
    }

    public void Activate()
    {
        if (Status == SubscriptionStatus.Active)
            throw new InvalidOperationException("Subscription already active.");

        Status = SubscriptionStatus.Active;
        Touch();
    }

    public void Cancel()
    {
        if (Status == SubscriptionStatus.Canceled)
            return;

        Status = SubscriptionStatus.Canceled;
        CanceledAt = DateTime.UtcNow;
        Touch();
    }

    public void AddPeriod(SubscriptionPeriod period)
    {
        _periods.Add(period);
        Touch();
    }
}
