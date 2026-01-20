using Memberships.Domain.Payments;

namespace Memberships.Application.Abstractions.Persistence;

public interface IPaymentRepository
{
    Task AddAsync(Payment payment, CancellationToken ct);
}
