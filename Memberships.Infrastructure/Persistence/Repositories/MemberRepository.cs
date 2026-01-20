using Microsoft.EntityFrameworkCore;
using Memberships.Application.Abstractions.Persistence;
using Memberships.Domain.Members;

namespace Memberships.Infrastructure.Persistence.Repositories;

public class MemberRepository : IMemberRepository
{
    private readonly MembershipsDbContext _db;

    public MemberRepository(MembershipsDbContext db)
    {
        _db = db;
    }

    public Task<Member?> GetByIdAsync(Guid id, CancellationToken ct)
        => _db.Members.FirstOrDefaultAsync(x => x.Id == id, ct);

    public Task<Member?> GetByEmailAsync(string email, CancellationToken ct)
        => _db.Members.FirstOrDefaultAsync(x => x.Email == email, ct);

    public async Task AddAsync(Member member, CancellationToken ct)
        => await _db.Members.AddAsync(member, ct);
}
