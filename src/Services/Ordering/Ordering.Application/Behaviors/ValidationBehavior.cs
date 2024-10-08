﻿
using FluentValidation;
using MediatR;
using Ordering.Application.Contracts;
using Ordering.Application.Exceptions;
using System.Windows.Input;

namespace Ordering.Application.Behaviors;
public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, IOrderCommand
    //where TResponse : IOrderResponse
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if(_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);
            var validationResults = await Task.WhenAll(
                _validators.Select(x => x.ValidateAsync(context, cancellationToken))
                );

            var failuers = validationResults.SelectMany(x => x.Errors)
                .Where(x => x != null)
                .ToList();

            if(failuers.Count > 0)
            {
                throw new AppValidationException(failuers);
            }
        }

        return await next();
    }
}
