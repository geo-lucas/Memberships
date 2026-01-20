using Memberships.Domain.Common;

namespace Memberships.Domain.Payments;

public class Payment : AuditableEntity
{
    public Guid SubscriptionId { get; private set; }
    public decimal Amount { get; private set; }
    public PaymentStatus Status { get; private set; }
    public DateTime AttemptedAt { get; private set; }

    private Payment() { }

    public Payment(Guid subscriptionId, decimal amount)
    {
        SubscriptionId = subscriptionId;
        Amount = amount;
        Status = PaymentStatus.Pending;
        AttemptedAt = DateTime.UtcNow;
    }

    public void Succeed()
    {
        Status = PaymentStatus.Succeeded;
        Touch();
    }

    public void Fail()
    {
        Status = PaymentStatus.Failed;
        Touch();
    }
}
