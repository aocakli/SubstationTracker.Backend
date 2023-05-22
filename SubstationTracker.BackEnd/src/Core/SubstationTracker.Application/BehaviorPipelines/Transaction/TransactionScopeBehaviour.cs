using System.Transactions;
using SubstationTracker.Application.BehaviorPipelines.Transaction.Enums;
using SubstationTracker.Application.Utilities.Exceptions;

namespace SubstationTracker.Application.BehaviorPipelines.Transaction;

public class TransactionScopeBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (request.GetType().GetCustomAttributes(false).Any(x => x.GetType() == typeof(UseTransaction)))
        {
            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required,
                       TransactionScopeAsyncFlowOption.Enabled))
            {
                var operationResult = await next();

                if (operationResult is IResponse response)
                {
                    if (response.IsSuccess)
                        transactionScope.Complete();
                    else
                        transactionScope.Dispose();
                }
                else
                    throw new ErrorException("Transaction is failed.");

                return operationResult;
            }
        }

        return await next();
    }
}