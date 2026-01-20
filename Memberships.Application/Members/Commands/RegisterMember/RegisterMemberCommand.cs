using MediatR;

namespace Memberships.Application.Members.Commands.RegisterMember;

public record RegisterMemberCommand(
    string Email,
    string FullName
) : IRequest<Guid>;
