using MediatR;
using Memberships.Application.Abstractions.Persistence;
using Memberships.Domain.Members;

namespace Memberships.Application.Members.Commands.RegisterMember;

public class RegisterMemberCommandHandler
    : IRequestHandler<RegisterMemberCommand, Guid>
{
    private readonly IMemberRepository _members;

    public RegisterMemberCommandHandler(IMemberRepository members)
    {
        _members = members;
    }

    public async Task<Guid> Handle(
        RegisterMemberCommand request,
        CancellationToken cancellationToken)
    {
        var existing = await _members
            .GetByEmailAsync(request.Email, cancellationToken);

        if (existing is not null)
            throw new InvalidOperationException("Member already exists.");

        var member = new Member(request.Email, request.FullName);

        await _members.AddAsync(member, cancellationToken);

        return member.Id;
    }
}
