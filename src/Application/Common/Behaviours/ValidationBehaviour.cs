using FluentValidation;
using MediatR;

namespace Application.Common.Behaviours;

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
            where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var failures = _validators.Select(async x => await x.ValidateAsync(context))
                .SelectMany(r => r.Result.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Count != 0)
            {
                var requestTypeName = request.GetType().Name;

                throw new ValidationException(failures);
            }
        }

        return await next();
    }
}