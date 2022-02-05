using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Options.Commands.DeleteOption
{
    public class DeleteOptionCommandHandler : IRequestHandler<DeleteOptionCommand>
    {
        private readonly IOptionRepository _optionRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteOptionCommandHandler> _logger;

        public DeleteOptionCommandHandler(IOptionRepository optionRepository, IMapper mapper, ILogger<DeleteOptionCommandHandler> logger)
        {
            _optionRepository = optionRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteOptionCommand request, CancellationToken cancellationToken)
        {
            Option optionToDelete = await _optionRepository.GetByIdAsync(request.Id);
            if (optionToDelete == null)
            {
                _logger.LogError($"No se encontro la Option Id {request.Id}");
                throw new NotFoundException(nameof(Option), request.Id);
            }

            await _optionRepository.DeleteAsync(optionToDelete);

            _logger.LogInformation($"Se eliminó de forma éxitosamente Option: {request.Id}");

            return Unit.Value;

        }
    }
}
