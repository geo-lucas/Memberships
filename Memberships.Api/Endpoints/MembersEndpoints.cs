using MediatR;
using Memberships.Application.Members.Commands.RegisterMember;
using Memberships.Application.Members.Queries.GetMemberById;

namespace Memberships.Api.Endpoints;

public static class MembersEndpoints
{
    public static void MapMembersEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/members", async (
            RegisterMemberCommand command,
            IMediator mediator,
            CancellationToken ct) =>
        {
            var id = await mediator.Send(command, ct);
            return Results.Created($"/members/{id}", new { id });
        });

        app.MapGet("/members/{id:guid}", async (
            Guid id,
            IMediator mediator,
            CancellationToken ct) =>
        {
            var member = await mediator.Send(
                new GetMemberByIdQuery(id), ct);

            return member is null
                ? Results.NotFound()
                : Results.Ok(member);
        });
    }
}
