using FluentValidation;
using MediatR;
using ValidationException = Application.Exceptions.ValidationException;

namespace Application.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {

        private readonly IEnumerable<IValidator<TRequest>> _validator;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validator)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_validator.Any())
            {
                ValidationContext<TRequest> context = new ValidationContext<TRequest>(request);

                var validationResults = await Task.WhenAll(_validator.Select(v => v.ValidateAsync(context, cancellationToken)));

                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Count != 0)
                {
                    throw new ValidationException(failures);
                }

            }
            return await next();
        }
    }
}
