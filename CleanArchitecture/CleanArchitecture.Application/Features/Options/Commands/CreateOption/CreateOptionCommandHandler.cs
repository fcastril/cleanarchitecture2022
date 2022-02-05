using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Options.Commands.CreateOpion
{
    public class CreateOptionCommandHandler : IRequestHandler<CreateOptionCommand, Guid>
    {
        private readonly IOptionRepository _optionRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateOptionCommandHandler> _logger;

        public CreateOptionCommandHandler(IOptionRepository optionRepository, IMapper mapper, ILogger<CreateOptionCommandHandler> logger)
        {
            _optionRepository = optionRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateOptionCommand request, CancellationToken cancellationToken)
        {
            Option optionEntity = _mapper.Map<Option>(request);
            Option optionNew = await _optionRepository.AddAsync(optionEntity);

            _logger.LogInformation($"Option {optionNew.Id} fue creado exitosamente");

            return optionNew.Id;

        }
    }
}
