using MediatR;
using Memberships.Application.Abstractions.Persistence;

namespace Memberships.Application.Members.Queries.GetMemberById;

public class GetMemberByIdQueryHandler
    : IRequestHandler<GetMemberByIdQuery, MemberDto?>
{
    private readonly IMemberRepository _members;

    public GetMemberByIdQueryHandler(IMemberRepository members)
    {
        _members = members;
    }

    public async Task<MemberDto?> Handle(
        GetMemberByIdQuery request,
        CancellationToken cancellationToken)
    {
        var member = await _members
            .GetByIdAsync(request.Id, cancellationToken);

        if (member is null)
            return null;

        return new MemberDto
        {
            Id = member.Id,
            Email = member.Email,
            FullName = member.FullName,
            IsActive = member.IsActive
        };
    }
}
