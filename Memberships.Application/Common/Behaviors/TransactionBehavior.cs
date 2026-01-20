using MediatR;
using Memberships.Application.Abstractions.Persistence;

namespace Memberships.Application.Common.Behaviors;

public class TransactionBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IUnitOfWork _unitOfWork;

    public TransactionBehavior(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var isCommand = request.GetType()
                               .Name
                               .EndsWith("Command", StringComparison.Ordinal);

        if (!isCommand)
            return await next();

        await _unitOfWork.BeginTransactionAsync(cancellationToken);

        var response = await next();

        await _unitOfWork.CommitTransactionAsync(cancellationToken);

        return response;
    }
}
