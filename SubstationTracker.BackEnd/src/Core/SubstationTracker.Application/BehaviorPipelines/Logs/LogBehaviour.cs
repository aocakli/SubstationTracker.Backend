using System.Text.Json;
using SubstationTracker.Application.BehaviorPipelines.Logs.Attributes;
using SubstationTracker.Application.Features.Users.OtherFeatures.UserLogs.Commands.CreateUserLog;

namespace SubstationTracker.Application.BehaviorPipelines.Logs;

public class LogBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IMediator _mediator;

    public LogBehaviour(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        LogTypeAttribute? logTypeAttribute = null;

        foreach (var attr in request.GetType().GetCustomAttributes(true))
        {
            if (attr is LogTypeAttribute logTypeAttr)
                logTypeAttribute = logTypeAttr;
        }

        CreateUserLogCommandRequest? createUserLogCommandRequest = null;

        string requestAsJson = JsonSerializer.Serialize(request);
        if (logTypeAttribute is not null)
            createUserLogCommandRequest = new CreateUserLogCommandRequest(
                type: logTypeAttribute.LogType,
                parameters: requestAsJson,
                isSuccess: false);

        var result = await next();

        if (logTypeAttribute is not null && result is IResponse response)
            createUserLogCommandRequest!.IsSuccess = response.IsSuccess;

        if (createUserLogCommandRequest is not null)
            await _mediator.Send(request: createUserLogCommandRequest, cancellationToken: cancellationToken);

        return result;
    }
}