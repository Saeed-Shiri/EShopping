﻿
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Contracts;

namespace Ordering.Application.Behaviours;
public class UnHandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, IOrderCommand
{

	private readonly ILogger<TRequest> _logger;

    public UnHandledExceptionBehaviour(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
		try
		{
			return await next();
		}
		catch (Exception e)
		{

			var resquestName = nameof(TRequest);
			_logger.LogError(e, $"Unhandled Exceptions occured with Requse Name: {resquestName}, {request}");
			throw;
		}
    }
}
