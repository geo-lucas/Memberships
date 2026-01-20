using Memberships.Domain.Common;
using Memberships.Domain.Billing;

namespace Memberships.Domain.Plans;

public class MembershipPlan : AuditableEntity
{
    public string Name { get; private set; } = default!;
    public decimal Price { get; private set; }
    public BillingInterval BillingInterval { get; private set; }
    public bool IsActive { get; private set; }

    private MembershipPlan() { }

    public MembershipPlan(string name, decimal price, BillingInterval billingInterval)
    {
        Name = name;
        Price = price;
        BillingInterval = billingInterval;
        IsActive = true;
    }

    public void Deactivate()
    {
        IsActive = false;
        Touch();
    }
}
