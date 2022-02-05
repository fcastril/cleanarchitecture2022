using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Options.Commands.UpdateOption
{
    public class UpdateOptionCommandHandler : IRequestHandler<UpdateOptionCommand>
    {
        private readonly IOptionRepository _optionRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateOptionCommandHandler> _logger;

        public UpdateOptionCommandHandler(IOptionRepository optionRepository, IMapper mapper, ILogger<UpdateOptionCommandHandler> logger)
        {
            _optionRepository = optionRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateOptionCommand request, CancellationToken cancellationToken)
        {
            Option optionToUpdate = await _optionRepository.GetByIdAsync(request.Id);
            if (optionToUpdate == null)
            {
                _logger.LogError($"No se encontro la Option Id {request.Id}");
                throw new NotFoundException(nameof(Option), request.Id);
            }

            _mapper.Map(request, optionToUpdate, typeof(UpdateOptionCommand), typeof(Option));

            await _optionRepository.UpdateAsync(optionToUpdate);

            _logger.LogInformation($"Se actualizó de forma éxitosamente Option: {request.Id}");

            return Unit.Value;
        }
    }
}
