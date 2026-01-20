using Memberships.Domain.Common;

namespace Memberships.Domain.Subscriptions;

public class SubscriptionPeriod : AuditableEntity
{
    public Guid SubscriptionId { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public bool IsPaid { get; private set; }

    private SubscriptionPeriod() { }

    public SubscriptionPeriod(Guid subscriptionId, DateTime startDate, DateTime endDate)
    {
        SubscriptionId = subscriptionId;
        StartDate = startDate;
        EndDate = endDate;
        IsPaid = false;
    }

    public void MarkAsPaid()
    {
        IsPaid = true;
        Touch();
    }
}
