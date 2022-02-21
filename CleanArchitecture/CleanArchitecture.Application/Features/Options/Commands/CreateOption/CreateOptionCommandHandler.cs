using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Options.Commands.CreateOpion
{
    public class CreateOptionCommandHandler : IRequestHandler<CreateOptionCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateOptionCommandHandler> _logger;

        public CreateOptionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateOptionCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateOptionCommand request, CancellationToken cancellationToken)
        {

            Option optionEntity = _mapper.Map<Option>(request);
            _unitOfWork.Repository<Option>().AddEntity(optionEntity);
            int result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                _logger.LogError($"Option {optionEntity.Id} no fue insertado");
                throw new Exception("No se pudo insertar la Opción");
            }


            _logger.LogInformation($"Option {optionEntity.Id} fue creado exitosamente");

            return optionEntity.Id;

        }
    }
}
