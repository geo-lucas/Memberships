using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Memberships.Domain.Subscriptions;

namespace Memberships.Infrastructure.Persistence.Configurations;

public class SubscriptionConfiguration
    : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.ToTable("Subscriptions");

        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.Periods)
            .WithOne()
            .HasForeignKey(p => p.SubscriptionId);

        builder.Property(x => x.Status)
            .IsRequired();
    }
}
